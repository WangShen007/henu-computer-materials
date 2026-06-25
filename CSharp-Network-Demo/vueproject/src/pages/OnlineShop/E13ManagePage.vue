<script setup>
    import message from '@/components/message.vue';
    import img1 from "/src/assets/manage/m1.png"
    import img2 from "/src/assets/manage/m2.png"
    import img3 from "/src/assets/manage/m3.png"
    import img4 from "/src/assets/manage/m4.png"
    import dropdownMenu from "/src/components/dropdownMenu.vue"
    import { onMounted, reactive, ref, inject } from "vue";
    import router from "@/router";

    const globalData = inject('$globalData');

    const messageTo = ref('');
    const type = ref('success');

    const goodsType = JSON.parse(sessionStorage.getItem('goodsType'))
    const allGoods = ref([])

    //const dialogVisible = ref(false)
    const currentShow = ref(1)
    const dialogVisibleFoot = ref(false)
    const editDialogVisible = ref(false)
    const searchDetail = ref("")
    const allCustomer = ref([])
    const allOrder = ref([])

    const form = reactive({
        "goodsId": 1,
        "goodsName": "",
        "goodsTypeId": 0,
        "goodsTypeName": '',
        "goodsDescript": "",
        "goodsUnitPrice": 0,
        "goodsImage": '',
        "sellCount": 1,
        "goodsDate": "2023-09-30"
    })
    const selectedType = ref(0)

    const formEmpty = reactive({
        "goodsId": 1,
        "goodsName": "",
        "goodsTypeId": 0,
        "goodsTypeName": '',
        "goodsDescript": "",
        "goodsUnitPrice": 0,
        "goodsImage": '',
        "sellCount": 1,
        "goodsDate": "2023-09-30"
    })
    const CustomerForm = reactive({
        customerId: "",
        customerPwd: "",
        customerName: "",
        customerAddress: "",
        customerPostCode: "",
        customerPhone: "",
        costomerEmail: "",
        customerRegDate: ""
    })
    const orderForm = reactive({
        "orderId": "",
        "customerId": "",
        "orderDate": "",
        "totalMoney": "",
        "orderState": "1"
    })

    const searchType = ref('全部种类');
    const allType = ref([]);

    // 获取商品类型数据
    const getGoodsType = () => {
        fetch('/api/GoodsTypes')
            .then(response => response.json())
            .then(data => {
                allType.value = data.slice(0, data.length);
                allType.value.splice(0, 0, {
                    goodsTypeId: 0,
                    goodsTypeName: "全部种类"
                });
            })
    };
    //删除商品种类
    const deleteType = (index) => {
        fetch("/api/GoodsTypes/" + index, {
            method: 'DELETE'
        })
            .then(response => {
                if (response.ok) {
                    messageFun("删除成功", "success")
                } else {
                    messageFun("删除失败", "error")
                }
            })
            .then(() => {
                getGoodsType();
            })
    };
    //新增商品种类
    const insertType = () => {
        document.getElementById('manageBtn2Close').click();
        fetch('/api/GoodsTypes', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(typeJson)
        })
            .then(response => {
                if (response.ok) {
                    messageFun("新增成功", "success")
                } else {
                    messageFun("新增失败", "error")
                }
            })
            .then(() => {
                getGoodsType();
            })
    };

    const operateType = ref('');
    const typeJson = reactive({
        "goodsTypeName": ""
    })

    const menuOption = [
        { imgSrc: img1, option: '商品管理', index: 0 },
        { imgSrc: img2, option: '商品种类管理', index: 1 },
        { imgSrc: img3, option: '订单处理', index: 2 },
        { imgSrc: img4, option: '顾客管理', index: 3 },
    ];

    const choosedOption = ref(0);
    const fileInput = ref(null);
    const toSearch = () => {
        fetch('/api/Goods')
            .then(r => r.json())
            .then(res => {
                if (globalData.globalVariable.goodsTypeId != 0) {
                    let temp = []
                    for (let i of res) {
                        if (i.goodsTypeId == globalData.globalVariable.goodsTypeId) {
                            temp.push(i)
                        }
                    }
                    temp = temp.filter(item => item.goodsName.includes(searchDetail.value))
                    allGoods.value = temp
                }
                else {
                    allGoods.value = res.filter(item => item.goodsName.includes(searchDetail.value))
                }
            })
    }
    const getAllGoods = () => {
        fetch('/api/Goods')
            .then(response => response.json())
            .then(data => {
                const types = JSON.parse(sessionStorage.getItem('goodsType'));
                for (let i = 0; i < data.length; i++) {
                    for (const type of types) {
                        if (data[i].goodsTypeId === type.goodsTypeId) {
                            data[i].goodsTypeName = type.goodsTypeName;
                            break;
                        }
                    }
                }
                allGoods.value = data;
            })
    };

    //商品详情
    const lookGoods = (index) => {
        Object.assign(form, allGoods.value[index]);
        selectedType.value = form.goodsTypeId;
        dialogVisibleFoot.value = false;
        operateType.value = 'look';
    }
    //商品编辑
    const editGoods = (index) => {
        Object.assign(form, allGoods.value[index]);
        selectedType.value = form.goodsTypeId;
        dialogVisibleFoot.value = true;
        operateType.value = 'edit';
    }
    //商品删除
    const deleteGoods = (index) => {
        fetch(`/api/Goods/${allGoods.value[index].goodsId}`, {
            method: 'DELETE'
        })
            .then(response => {
                if (response.ok) {
                    messageFun("删除商品成功", "success")
                } else {
                    messageFun("删除商品失败", "error")
                }
            })
            .then(() => {
                getAllGoods();
            })
    }

    const messageFun = (messageNeed, typeNeed) => {
        open.value = true;
        messageTo.value = messageNeed;
        type.value = typeNeed;
        setTimeout(() => {
            open.value = false;
        }, 5000);
    };
    const open = ref(false);

    //新增商品
    const insertGoods = () => {
        Object.assign(form, formEmpty);
        dialogVisibleFoot.value = true;
        operateType.value = 'insert'
    }
    //0：顾客，1：管理员
    const userInfo = reactive({
        user: null,
        identity: 0
    });
    const getUser = () => {
        if (sessionStorage.getItem('manager') !== null) {
            userInfo.user = JSON.parse(sessionStorage.getItem('manager'))
            userInfo.identity = 1
        } else {
            if (sessionStorage.getItem('user') !== null) {
                userInfo.user = JSON.parse(sessionStorage.getItem('user'))
                userInfo.identity = 0
            }
        }
    }

    //单击按钮打开隐藏的上传图片输入框
    const openFileInput = () => {
        fileInput.value.click();
    };
    //注销
    const logout = () => {
        sessionStorage.removeItem('manager');
        sessionStorage.removeItem('user');
        userInfo.user = null;
        router.push('/home');
    }
    //保存商品编辑
    const saveEdit = () => {
        document.getElementById('manageBtn1Close').click();
        form.goodsTypeId = selectedType.value;
        if (operateType.value === 'edit') {
            fetch(`/api/Goods/${form.goodsId}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(form)
            })
                .then(response => {
                    if (response.ok) {
                        messageFun("保存成功", "success")
                        getAllGoods();
                    } else {
                        messageFun("保存失败", "error")
                    }
                });
        } else if (operateType.value === 'insert') {
            delete form.goodsId;
            form.goodsDate = new Date(new Date().getTime() + 8 * 60 * 60 * 1000);
            fetch('/api/Goods/', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(form)
            })
                .then(response => {
                    if (response.ok) {
                        messageFun("新增商品成功", "success")
                        getAllGoods();
                        Object.assign(form, formEmpty);
                    } else {
                        messageFun("新增商品失败", "error")
                    }
                });
        }
    }

    // 处理文件选择事件，将上传的图片转换为 Base64
    const handleFileChange = (event) => {
        const file = event.target.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onloadend = () => {
                form.goodsImage = reader.result;
            };
            reader.readAsDataURL(file);
        }
    };

    //控制弹出框：顾客管理（详情、编辑）
    const dialogVisible1 = ref(false);
    const getallCustomer = () => {
        fetch('/api/Customers')
            .then(response => response.json())
            .then(data => {
                allCustomer.value = data;
            })
    }
    const delCustomer = (id) => {
        fetch('/api/Customers/' + id, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json', // 设置请求头，根据需要修改
                // 可以添加其他请求头
            },
        }).then(() => {
            getallCustomer();
        })
    }
    //顾客管理（详情）
    const showCustomer = (id) => {
        dialogVisible1.value = true;
        console.log(allCustomer.value);
        console.log(allCustomer.value.length);
        for (let i = 0; i < allCustomer.value.length; i++) {
            if (allCustomer.value[i].customerId === id) {
                CustomerForm.value = allCustomer.value[i];
                console.log(CustomerForm);
                break;
            }
        }
    }
    //顾客管理（编辑）
    const changeCustomer = (id) => {
        editDialogVisible.value = true
        console.log(allCustomer.value)
        console.log(allCustomer.value.length)
        for (let i = 0; i < allCustomer.value.length; i++) {
            if (allCustomer.value[i].customerId === id) {
                CustomerForm.value = allCustomer.value[i];
                console.log(CustomerForm);
                oldId.value = CustomerForm.value.customerId;
                break;
            }
        }
    }
    const oldId = ref("");
    //顾客管理（保存编辑）
    const yes = () => {
        console.log(CustomerForm.value.customerId)
        editDialogVisible.value = false;
        if (CustomerForm.value.customerId == oldId.value) {
            //修改
            fetch('/api/Customers/' + CustomerForm.value.customerId, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(CustomerForm.value)
            })
                .then(response => {
                    if (response.ok) {
                        messageFun("修改成功！", "success");
                    } else {
                        alert("修改失败！");
                    }
                });
        }else {
            //先插入
            fetch('/api/Customers', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(CustomerForm.value)
            })
                .then(response => {
                    if (response.ok) {
                        if (CustomerForm.value.customerId != oldId.value) {
                            //再删除
                            delCustomer(oldId.value);
                        }
                        messageFun("修改成功！", "success")
                    } else {
                        alert("修改失败，已有该用户ID！");
                    }
                });
        }
    }

    //订单管理
    const getallOrder = () => {
        fetch('/api/UserOrders')
            .then(response => response.json())
            .then(data => {
                allOrder.value = data;
            })
    }
    const prossOrder = (id) => {
        for (let i = 0; i < allOrder.value.length; i++) {
            if (allOrder.value[i].orderId === id) {
                console.log(orderForm)
                orderForm.orderId = allOrder.value[i].orderId;
                orderForm.customerId = allOrder.value[i].customerId;
                orderForm.orderDate = allOrder.value[i].orderDate;
                orderForm.totalMoney = allOrder.value[i].totalMoney;
                break;
            }
        }
        fetch('/api/UserOrders/' + id, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(orderForm)
        })
            .then(response => {
                if (response.ok) {
                    messageFun("处理成功！", "success")
                    getallOrder()
                }
            },
            );
    };

    onMounted(() => {
        getAllGoods()
        getGoodsType()
        getUser()
        getallCustomer()
        getallOrder()
    })
</script>

<template>
    <div v-if="userInfo.user">
        <message v-if="open" :message=messageTo :type=type @dismiss="open=false"></message>
        <div class="row">
            <div class="col text-center">
                <span style="font-size:24px;">管理菜单（管理员：{{ userInfo.identity === 0 ? userInfo.user.customerName : userInfo.user.managerId }}）</span>
                <span style="margin-left: 30px; font-size: 20px; color:blue; cursor: pointer;" @click="logout">注销</span>
            </div>
        </div>
        <div class="row mx-auto w-75">
            <div class="col-3 line" v-for="(option, index) in menuOption" :key="index" @click="choosedOption = index"
                 :style="choosedOption === index ? 'color:#F1652D' : ''">
                <img :src="option.imgSrc" alt="">{{ option.option }}
            </div>
        </div>
        <div class="pageWrapper">
            <div class="pageContent">
                <div class="line2">
                    <div class="line2Left">
                        <img src="@/assets/manage/m5.png" alt="">
                        <span style="white-space: nowrap;">
                            {{ menuOption[choosedOption].option }}
                            <span v-if="choosedOption == 0 || choosedOption == 1 || choosedOption == 2 || choosedOption == 3">（总数：</span>
                        </span>
                        <span style="color: #F1652D" v-if="choosedOption == 0"> {{ allGoods.length }}</span>
                        <span style="color: #F1652D" v-if="choosedOption == 1"> {{ allType.length - 1 }}</span>
                        <span style="color: #F1652D" v-if="choosedOption == 2"> {{ allOrder.length }}</span>
                        <span style="color: #F1652D" v-if="choosedOption == 3"> {{ allCustomer.length }}</span>
                        <span v-if="choosedOption == 0 || choosedOption == 1 || choosedOption == 2 || choosedOption == 3">）</span>
                    </div>
                    <div class="line2Right">
                        <div class="searchBoxWrapper" v-if="choosedOption == 0">
                            <div class="searchBox">
                                <dropdownMenu :allType="allType"></dropdownMenu>
                                <input placeholder="请输入产品名称" class="searchInput" v-model="searchDetail">
                                <div class="cutOffLine"></div>
                                <div class="searchIconBox" @click="toSearch">
                                    <img src="@/assets/navigation/搜索.png" alt="">
                                </div>
                            </div>
                        </div>
                        <div class="insertGoods" @click="insertGoods" v-if="choosedOption == 0"
                             data-bs-toggle="modal" data-bs-target="#myModal1">
                            新增商品
                        </div>
                        <div class="insertGoods" v-if="choosedOption==1"
                             data-bs-toggle="modal" data-bs-target="#myModal2">
                            新增商品种类
                        </div>
                    </div>
                </div>
                <div v-if="choosedOption == 1">
                    <table class="bordered-table">
                        <thead>
                            <tr>
                                <th>种类编号</th>
                                <th>种类名称</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="item, index in allType">
                                <td v-if="index != 0">{{ item.goodsTypeId }}</td>
                                <td v-if="index != 0">{{ item.goodsTypeName }}</td>
                                <td v-if="index != 0" style="cursor: pointer; color: #F1652D; font-size: 14px;"
                                    @click="deleteType(item.goodsTypeId)">
                                    删除
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <div class="line3" v-for="(goods, index) in allGoods" :key="index" v-if="choosedOption == 0">
                    <table class="table table-borderless">
                        <tbody>
                            <tr>
                                <td>
                                    <img :src="goods.goodsImage" alt="无图片" class="column1">
                                </td>
                                <td>
                                    <div class="column2">
                                        <div class="infoTitle1">{{ goods.goodsName }}</div>
                                        <div class="goodsDescript">{{ goods.goodsDescript }}</div>
                                    </div>
                                </td>
                                <td>
                                    <div class="column3">
                                        <div class="infoTitle2">商品种类</div>
                                        <div class="goodsInfo">{{ goods.goodsTypeName }}</div>
                                    </div>
                                </td>
                                <td>
                                    <div class="column4">
                                        <div class="infoTitle2">商品单价</div>
                                        <div class="goodsInfo">
                                            <span class="money">￥ </span>{{ goods.goodsUnitPrice }}
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="column4">
                                        <div class="infoTitle2">上架时间</div>
                                        <div class="goodsInfo">{{ goods.goodsDate }}</div>
                                    </div>
                                </td>
                                <td>
                                    <div class="column6">
                                        <div>操作</div>
                                        <div class="operateBox">
                                            <div @click="lookGoods(index)" data-bs-toggle="modal" data-bs-target="#myModal1">详情</div>
                                            <div @click="editGoods(index)" data-bs-toggle="modal" data-bs-target="#myModal1">编辑</div>
                                            <div @click="deleteGoods(index)">删除</div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div v-if="choosedOption == 2">
                    <div v-if="allOrder.length == 0" style="margin: 20px;">未查询到订单信息！</div>
                    <table class="bordered-table" v-else>
                        <thead>
                            <tr>
                                <th>用户ID</th>
                                <th>订单时间</th>
                                <th>订单金额</th>
                                <th>订单状态</th>
                                <th>处理订单</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="item in allOrder" :key="item.customerId">
                                <td>{{ item.customerId }}</td>
                                <td>{{ item.orderDate }}</td>
                                <td>{{ item.totalMoney }}</td>
                                <td v-if="item.orderState == 0">未处理</td>
                                <td v-if="item.orderState == 1">已处理</td>
                                <td>
                                    <span style="cursor: pointer;color: #F1652D;font-size: 14px;"
                                          @click="prossOrder(item.orderId)">处理</span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div v-if="choosedOption == 3">
                    <div v-if="allCustomer.length == 0" style="margin: 20px;">未查询到顾客信息！</div>
                    <table class="bordered-table" v-else>
                        <thead>
                            <tr>
                                <th>用户ID</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="item in allCustomer" :key="item.customerId">
                                <td>{{ item.customerId }}</td>
                                <td>
                                    <span style="cursor: pointer;color: #F1652D;font-size: 14px;"
                                          @click="showCustomer(item.customerId)">详情</span>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <span style="cursor: pointer;color: #F1652D;font-size: 14px;"
                                          @click="changeCustomer(item.customerId)">编辑</span>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <span style="cursor: pointer;color: #F1652D;font-size: 14px;"
                                          @click="delCustomer(item.customerId)">删除</span>&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div v-else>
        错误入口，请从【管理入口】进入此页面。
    </div>
    <div class="modal_container" v-if="dialogVisible1">
        <div class="modal1" v-if="dialogVisible1">
            <span class="tanregistword">顾客信息</span>
            <div class="my-modal-content">
                <div class="form-group">
                    <div style="display: flex;margin-left: 30px;">
                        <label for="customerId" style="width: 70px;">用户ID:</label>
                        <input type="text" readonly v-model="CustomerForm.value.customerId"
                               class="taninput" style="background:#E0E0E0"><br><br>
                    </div>
                    <div style="display: flex;margin-left: 30px;">
                        <label for="customerName" style="width: 70px;">用户名:</label>
                        <input type="text" readonly v-model="CustomerForm.value.customerName"
                               class="taninput" style="background:#E0E0E0"><br><br>
                    </div>
                    <div style="display: flex;margin-left: 30px;">
                        <label for="customerPwd" style="width: 70px;">密码:</label>
                        <input type="text" readonly v-model="CustomerForm.value.customerPwd"
                               class="taninput" style="background:#E0E0E0"><br><br>
                    </div>
                    <div style="display: flex;margin-left: 30px;">
                        <label for="customerAddress" style="width: 70px;">住址:</label>
                        <input type="text" readonly v-model="CustomerForm.value.customerAddress"
                               class="taninput" style="background:#E0E0E0"><br><br>
                    </div>
                    <div style="display: flex;margin-left: 30px;">
                        <label for="customerPostCode" style="width: 70px;">邮编:</label>
                        <input type="text" readonly v-model="CustomerForm.value.customerPostCode"
                               class="taninput" style="background:#E0E0E0"><br><br>
                    </div>
                    <div style="display: flex;margin-left: 30px;">
                        <label for="customerPhone" style="width: 70px;">手机号:</label>
                        <input type="text" readonly v-model="CustomerForm.value.customerPhone"
                               class="taninput" style="background:#E0E0E0"><br><br>
                    </div>
                    <div style="display: flex;margin-left: 30px;">
                        <label for="customerEmail" style="width: 70px;">邮箱:</label>
                        <input type="text" readonly v-model="CustomerForm.value.costomerEmail"
                               class="taninput" style="background:#E0E0E0"><br><br>
                    </div>
                    <div class="dialog-footer">
                        <button type="button" class="btn btn-primary" @click="dialogVisible1 = false" style="margin-right: 30px;">取消</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal_container" v-if="editDialogVisible">
        <div class="modal1" v-if="editDialogVisible">
            <span class="tanregistword">修改顾客信息</span>
            <div class="my-modal-content">
                <div class="form-group">
                    <div style="display: flex;margin-left: 30px;">
                        <label for="customerId" style="width: 70px;">*用户ID:</label>
                        <input type="text" v-model="CustomerForm.value.customerId" class="taninput"><br><br>
                    </div>
                    <div style="display: flex;margin-left: 30px;">
                        <label for="customerName" style="width: 70px;">*用户名:</label>
                        <input type="text" v-model="CustomerForm.value.customerName" class="taninput"><br><br>
                    </div>
                    <div style="display: flex;margin-left: 30px;">
                        <label for="customerPwd" style="width: 70px;">*密码:</label>
                        <input type="text" v-model="CustomerForm.value.customerPwd" class="taninput"><br><br>
                    </div>
                    <div style="display: flex;margin-left: 30px;">
                        <label for="customerAddress" style="width: 70px;">住址:</label>
                        <input type="text" v-model="CustomerForm.value.customerAddress" class="taninput"><br><br>
                    </div>
                    <div style="display: flex;margin-left: 30px;">
                        <label for="customerPostCode" style="width: 70px;">邮编:</label>
                        <input type="text" v-model="CustomerForm.value.customerPostCode" class="taninput"><br><br>
                    </div>
                    <div style="display: flex;margin-left: 30px;">
                        <label for="customerPhone" style="width: 70px;">手机号:</label>
                        <input type="text" v-model="CustomerForm.value.customerPhone" class="taninput"><br><br>
                    </div>
                    <div style="display: flex;margin-left: 30px;">
                        <label for="customerEmail" style="width: 70px;">邮箱:</label>
                        <input type="text" v-model="CustomerForm.value.costomerEmail" class="taninput"><br><br>
                    </div>
                    <div class="dialog-footer">
                        <button type="button" class="btn btn-primary" @click="editDialogVisible = false" style="margin-right: 30px;">取消</button>
                        <button type="submit" class="btn btn-primary" @click="yes" style="margin-right: 30px;">确定</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- 正常宽度（默认），超大宽度（modal-xl），较大宽度（modal-lg），较小宽度（modal-sm）-->
    <!-- 商品详情、商品编辑 -->
    <div class="modal modal-xl" id="myModal1">
        <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" v-if="dialogVisibleFoot">编辑商品</h4>
                    <h4 class="modal-title" v-else>商品详情</h4>
                    <button id="manageBtn1Close" type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <span class="col-auto" border>商品名称</span>
                            <input type="text" class="col-4 border" v-model="form.goodsName" v-bind:disabled="!dialogVisibleFoot">
                            <span class="col-auto offset-1">商品类别</span>
                            <select v-model="selectedType"
                                    style="width: 287px;height: 36px;margin-left: 20px;  border: 1px solid #E0E0E0;"
                                    v-bind:disabled="!dialogVisibleFoot">
                                <option v-for="option in goodsType" :key="option.goodsTypeId" :label="option.goodsTypeName"
                                        :value="option.goodsTypeId"></option>
                            </select>
                        </div>
                        <div class="row mt-3">
                            <div class="col-auto">商品描述</div>
                            <textarea type="text" class="col-10" v-model="form.goodsDescript" v-bind:disabled="!dialogVisibleFoot" />
                        </div>
                        <div class="row mt-3">
                            <span class="col-auto">商品单价</span>
                            <input type="text" class="col-10" v-model="form.goodsUnitPrice"
                                   v-bind:disabled="!dialogVisibleFoot">
                        </div>
                        <div class="row mt-3">
                            <span class="col-auto">上架时间</span>
                            <input type="text" class="col-10" v-model="form.goodsDate"
                                   v-bind:disabled="!dialogVisibleFoot">
                        </div>
                        <div class="row mt-3 mb-3">
                            <div class="col-auto">商品图片</div>
                            <button class="col-2 btn btn-primary" style="height:40px"
                                    @click="openFileInput"
                                    v-if="dialogVisibleFoot">
                                上传图片
                            </button>
                            <input type="file" accept="image/*" ref="fileInput" style="display: none" @change="handleFileChange"
                                   v-bind:disabled="!dialogVisibleFoot">
                            <img :src="form.goodsImage" class="col-8" alt="">
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="submit" class="btn btn-primary" style="margin-right: 30px;"
                            @click="saveEdit"
                            v-if="dialogVisibleFoot">
                        保 存
                    </button>
                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal">取 消</button>
                </div>
            </div>
        </div>
    </div>

    <!-- 新增商品种类 -->
    <div class="modal" id="myModal2">
        <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">新增商品种类</h4>
                    <button id="manageBtn2Close" type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <span class="col-auto" border>商品种类名称</span>
                            <input type="text" class="col-6 border" v-model="typeJson.goodsTypeName">
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="submit" class="btn btn-primary" style="margin-right: 30px;"
                            @click="insertType">
                        保 存
                    </button>
                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal">取 消</button>
                </div>
            </div>
        </div>
    </div>

</template>

<style scoped>
      /*  @media screen and (max-width: 1700px) {
      .manageOrder {
        display: none;
      }
      .pageRight {
        margin-left: 70px !important;
      }
    }*/

/*      .modal2 {
          position: absolute;
          overflow: auto;
          width: 50vw;
          height: 95vh;
          max-height: 700px;
          min-width: 500px;
          background-color: white;
          border-radius: 4px;
          border: 1px rgb(201, 201, 201) solid;
          box-shadow: 0 8px 8px rgba(0, 0, 0, 0.2);
      }*/

      .modal1 {
          z-index: 999;
          height: 95vh;
          max-height: 500px;
          margin: auto;
          position: absolute;
          top: 0;
          left: 0;
          right: 0;
          bottom: 0;
          width: 470px;
          background-color: white;
          border-radius: 4px;
          border: 1px rgb(201, 201, 201) solid;
          box-shadow: 0 8px 8px rgba(0, 0, 0, 0.2);
      }

      .my-modal-container {
          background-color: rgba(0, 0, 0, 0.2);
          height: 100vh;
          top: 0;
          left: 0;
          width: 100vw;
          z-index: 888;
          position: fixed;
          display: flex;
          align-items: center;
          justify-content: center;
      }

      .bordered-table {
          border-collapse: collapse;
          width: 100%;
      }
          .bordered-table th,
          .bordered-table td {
              border: 1px solid #ddd;
              padding: 8px;
              text-align: left;
          }
          .bordered-table th {
              background-color: #f2f2f2;
          }
          .bordered-table tr:nth-child(even) {
              background-color: #f9f9f9;
          }
          .bordered-table tr:hover {
              background-color: #e9e9e9;
          }

      .leftColumn {
          display: flex;
      }

      .colum234 {
          display: flex;
          padding-right: 60px;
      }

      .pageWrapper {
          background: #F5F5F5;
      }

      .pageContent {
          padding: 10px;
          width: 100%;
      }

      .line {
          cursor: pointer;
          margin: 15px 0;
          font-size: 16px;
          font-weight: 600;
          color: #333333;
          line-height: 20px;
      }

          .line > img {
              margin-right: 10px;
          }

      .line2 {
          height: 60px;
          background: #FFFFFF;
          border-radius: 4px 4px 4px 4px;
          opacity: 1;
          display: flex;
          align-items: center;
          justify-content: space-between;
      }

      .line2Left {
          display: flex;
          min-width: 160px;
          margin-left: 25px;
          align-items: center;
          border: 1px solid #E0E0E0;
      }

          .line2Left > img {
              margin-left: 15px;
              margin-right: 10px;
          }

      .line2Right {
          display: flex;
          margin-right: 10px;
      }

      .searchBoxWrapper {
          width: 360px;
          height: 48px;
          border-radius: 4px 4px 4px 4px;
          opacity: 1;
          border: 1px solid #E0E0E0;
          display: flex;
          align-items: center;
          margin: 0 12px;
          position: relative;
          cursor: pointer;
      }

      .searchBox {
          display: flex;
      }

      .searchType {
          margin-left: 5px;
          width: 60px;
          height: 20px;
          font-size: 15px;
          font-weight: 400;
          color: #333333;
          line-height: 20px;
          display: flex;
          justify-content: center;
      }

      .selectType {
          display: flex;
          align-items: center;
      }

      .searchTypeMoreIcon {
          width: 15px;
          height: 8px;
          margin-left: 14px;
      }

      .searchInput {
          background: none;
          border: none;
          padding-left: 10px;
      }

      .cutOffLine {
          width: 1px;
          height: 48px;
          background-color: #E0E0E0;
          position: absolute;
          right: 84px;
          top: 0;
      }

      .searchIconBox {
          width: 84px;
          height: 48px;
          position: absolute;
          right: 0;
          top: 0;
          display: flex;
          align-items: center;
          justify-content: center;
          cursor: pointer;
      }

      /* 商品详细信息行 */
      .line3 {
          margin-top: 10px;
          height: 100px;
          background: #FFFFFF;
          border-radius: 4px 4px 4px 4px;
          opacity: 1;
      }
      /* 商品图片 */
      .column1 {
          width: 80px;
          height: 80px;
          align-items: center;
          margin: 0;
      }
      /* 商品描述 */
      .column2 {
          margin: 0 5px 0 0;
      }
      /* 商品名称 */
      .infoTitle1 {
          font-size: 16px;
          font-weight: 400;
          color: #333333;
          line-height: 20px;
      }
      /* 商品描述 */
      .goodsDescript {
          width: 15vw;
          min-width: none;
          margin-top: 5px;
          font-size: 12px;
          font-weight: 400;
          color: #9E9E9E;
          line-height: 20px;
      }

      /* 商品种类 */
      .column3 {
          min-width: 60px;
          margin-left: 5px;
          margin-top: 5px;
          text-align: center;
      }

      .infoTitle2 {
          font-size: 16px;
          font-weight: 400;
          color: #333333;
          line-height: 20px;
      }

      .goodsInfo {
          margin-top: 15px;
          font-size: 14px;
      }

      /* 商品单价、上架时间 */
      .column4 {
          min-width: 40px;
          margin-left: 5px;
          margin-top: 5px;
          text-align: center;
      }

      .money {
          font-size: 14px;
          font-weight: 400;
          color: #333333;
          line-height: 18px;
      }

      /* 操作 */
      .column6 {
          min-width: 100px;
          padding-right: 5px;
          margin-top: 5px;
          margin-left: 5px;
          text-align: center;
      }

      .operateBox {
          display: flex;
          flex-wrap: wrap;
          margin-top: 10px;
      }

          .operateBox > div {
              min-width: 40px;
              margin-bottom: 10px;
              white-space: nowrap;
              flex: 1;
              font-size: 14px;
              cursor: pointer;
              font-weight: 400;
              color: #F1652D;
              line-height: 20px;
          }

      .line4 {
          margin-top: 36px;
          padding-left: 40px;
      }

      .goodsName {
          white-space: nowrap;
          font-size: 16px;
          font-weight: 400;
          color: #333333;
          line-height: 34px;
      }

      .goodsType {
          font-size: 16px;
          font-weight: 400;
          color: #333333;
          line-height: 21px;
      }

      .goodnameinput {
          margin-left: 20px;
          padding-left: 20px;
          width: 300px;
          height: 32px;
          border: 1px solid #E0E0E0;
          outline: none;
      }


      .goodtypeinput {
          margin-left: 20px;
          width: 300px;
          height: 32px;
          border: 1px solid #E0E0E0;
          outline: none;
      }

      .line5 {
          margin-top: 20px;
          padding-left: 40px;
          display: flex;
      }

      .goodshow {
          font-size: 16px;
          font-weight: 400;
          color: #333333;
      }

      .goodshowinput {
          padding-left: 20px;
          padding-top: 10px;
          margin-left: 20px;
          width: 751px;
          height: 200px;
          font-family: Microsoft YaHei-Regular, Microsoft YaHei;
          border: 1px solid #E0E0E0;
          font-size: 16px;
          font-weight: 400;
          color: #333333;
          line-height: 21px;
      }

      .goodmuch {
          font-size: 16px;
          font-family: Microsoft YaHei-Regular, Microsoft YaHei;
          font-weight: 400;
          color: #333333;
          line-height: 21px;
      }

      .goodmuchinput {
          margin-left: 20px;
          padding-left: 20px;
          width: 300px;
          height: 32px;
          border: 1px solid #E0E0E0;
          outline: none;
      }

/*      .save {
          position: absolute;
          bottom: 20px;
          left: 732px;
          width: 100px;
          height: 48px;
          background: #F1652D;
          border-radius: 8px 8px 8px 8px;
          opacity: 1;
          display: flex;
          align-items: center;
          justify-content: center;
          color: #FFFFFF;
          cursor: pointer;
      }*/

/*      .cancel {
          position: absolute;
          bottom: 20px;
          left: 852px;
          width: 110px;
          height: 48px;
          border-radius: 8px 8px 8px 8px;
          opacity: 1;
          border: 1px solid #E0E0E0;
          display: flex;
          align-items: center;
          justify-content: center;
          color: #F1652D;
          cursor: pointer;
      }*/

      .goodsImgBox {
          display: flex;
          margin-top: 20px;
          padding-left: 40px;
      }

      .goodimg {
          width: 64px;
          height: 21px;
          font-size: 16px;
          font-family: Microsoft YaHei-Regular, Microsoft YaHei;
          font-weight: 400;
          color: #333333;
          line-height: 21px;
      }

      .goodsImgBox > img {
          width: 110px;
          height: 110px;
          margin-left: 20px;
      }

      .uploadImg {
          cursor: pointer;
          margin-left: 20px;
          display: flex;
          justify-content: center;
          align-items: center;
          font-size: 15px;
          color: #F1652D;
          width: 110px;
          height: 110px;
          border-radius: 4px 4px 4px 4px;
          opacity: 1;
          border: 1px solid #E0E0E0;
      }

      .insertGoods {
          width: 110px;
          height: 48px;
          background: #F1652D;
          border-radius: 8px 8px 8px 8px;
          opacity: 1;
          font-size: 15px;
          color: #FFFFFF;
          display: flex;
          align-items: center;
          justify-content: center;
          cursor: pointer;
          margin-right: 20px;
          margin-left: 20px;
      }

      .dialog-footer {
          text-align: right;
          margin-right: 10px;
          margin-bottom: 10px;
          margin-top: 20px;
      }

      .tanregistword {
          margin-top: 30px;
          margin-bottom: 20px;
          display: flex;
          justify-content: center;
          color: black;
          font-size: 22px;
      }

/*      button {
          background-color: #007bff;
          color: #fff;
          padding: 10px 20px;
          border: none;
          border-radius: 4px;
          font-size: 16px;
          cursor: pointer;
      }*/

      .taninput {
          width: 300px;
          margin-bottom: 20px;
          height: 20px;
          padding: 5px;
          border: 1px solid #ccc;
          border-radius: 4px;
      }
</style>
