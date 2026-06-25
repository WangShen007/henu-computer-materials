<script setup>
    import message from "@/components/message.vue";
    import { onMounted, reactive, ref, inject, watch } from 'vue';
    import router from "@/router";
    import dropdownMenu from "@/components/dropdownMenu.vue"

    const globalData = inject('$globalData');
    const searchData = inject('$searchData');
    const toSearch = () => {
        searchData.globalVariable.data = production.value
        searchData.globalVariable.flag = !searchData.globalVariable.flag
        console.log(searchData)
    }
    watch(globalData, (newVal) => {
        selectedTypeIndex.value = newVal.globalVariable.goodsTypeName
    });
    const goodsType = ref([]);
    const allType = ref([]);
    const showMoreType = ref(false);
    const moreType = ref([]);
    const selectedTypeIndex = ref("");
    const production = ref("")
    // provide('$globalData', selectedTypeIndex);
    const searchType = ref('全部种类');
    const orderDialog = ref(false)
    const helpDialog = ref(false)
    const form = reactive({})
    const dialogVisible = ref(false)
    const isOpen = ref(false);
    const messageTo = ref("")
    const open = ref(false)
    const type = ref("success")
    const orderIdlist = ref([]);
    const goodsidlist = ref([]);
    const goodsNamelist = ref([]);
    const UserOrders = ref([]);

    const userInfo = reactive({
        user: null,
        identity: 0
    });
    const messageFun = (messageNeed, typeNeed) => {
        open.value = true
        messageTo.value = messageNeed
        type.value = typeNeed
        setTimeout(() => {
            open.value = false
        }, 2000);
    }
    const showDropdown = () => {
        isOpen.value = true;
    };
    const hideDropdown = () => {
        isOpen.value = false;
    };
    const getGoodsType = () => {
        fetch('/api/GoodsTypes')
            .then(r => r.json())
            .then(res => {
                allType.value = res.slice(0, res.length)
                sessionStorage.setItem('goodsType', JSON.stringify(allType.value))
                allType.value.splice(0, 0, {
                    "goodsTypeId": 0,
                    "goodsTypeName": "全部种类"
                })
                if (res.length <= 8) {
                    goodsType.value = res
                } else {
                    showMoreType.value = true;
                    goodsType.value = res.slice(0, 8);
                    moreType.value = res.slice(8);
                }
                return;
            });
    }
    const yes = () => {
        fetch('/api/Customers/' + form.customerId, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(form)
        })
            .then(response => {
                if (response.ok) {
                    sessionStorage.setItem('user', JSON.stringify(form));
                    getUser();
                    const btn2Close = document.getElementById('btn2Close');
                    alert("修改成功！");
                    btn2Close.click();
                }
            });
    };

    const logout = () => {
        sessionStorage.removeItem('manager');
        sessionStorage.removeItem('user');
        userInfo.user = null;
        router.push('/home');
    }

    const selectType = (index) => {
        selectedTypeIndex.value = index.goodsTypeName
        globalData.globalVariable = index
    }
    const selectTypeDrop = (index) => {
        selectedTypeIndex.value = index.goodsTypeName
        globalData.globalVariable = index
        isOpen.value = false
    }
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

    const register = () => {
        router.push({
            path: '/userRegister',
            query: {
                register: 1
            }
        })
    }
    const orderdetail = () => {
        fetch('/api/UserOrders')
            .then(response => response.json())
            .then(res => {
                UserOrders.value = res
                orderDialog.value = true
            })
    }

    const orderdetails = () => {
        orderIdlist.value = []
        goodsidlist.value = []
        goodsNamelist.value = []
        console.log(JSON.parse(sessionStorage.getItem('user')))
        const userid = JSON.parse(sessionStorage.getItem('user')).customerId;

        console.log("userid", userid)
        const goodsType = {};

        fetch('/api/Goods')
            .then(response3 => response3.json())
            .then(GoodsResponse => {
                for (let j = 0; j < GoodsResponse.length; j++) {
                    goodsType[GoodsResponse[j].goodsId] = GoodsResponse[j].goodsName;
                }

                console.log("goodsType", goodsType)

                fetch('/api/UserOrders')
                    .then(response => response.json())
                    .then(successResponse => {
                        for (let i = 0; i < successResponse.length; i++) {
                            if (successResponse[i].customerId === userid) {
                                orderIdlist.value.push(successResponse[i].orderId);
                            }
                        }
                        async function processOrders() {
                            for (let i = 0; i < orderIdlist.value.length; i++) {
                                await fetch('/api/OrderDetails')
                                    .then(response2 => response2.json())
                                    .then(orderDetailsResponse => {
                                        for (let j = 0; j < orderDetailsResponse.length; j++) {
                                            if (orderDetailsResponse[j].orderId === orderIdlist.value[i]) {
                                                goodsidlist.value.push(orderDetailsResponse[j].goodsId);
                                            }
                                        }
                                    });
                            }
                            // 第一个 for 循环执行完毕后，执行第二个 for 循环
                            for (let k = 0; k < goodsidlist.value.length; k++) {
                                const keys = Object.keys(goodsType);
                                // 遍历 keys 数组
                                for (let i = 0; i < keys.length; i++) {
                                    const key = keys[i];
                                    if (key == goodsidlist.value[k]) {
                                        goodsNamelist.value.push(goodsType[key]);
                                        break;
                                    }
                                }
                            }
                        }
                        processOrders();
                    })
            });
        orderDialog.value = true
        console.log("orderIdlist", orderIdlist.value)
        console.log("goodsidlist", goodsidlist.value)
        console.log("goodsNamelist", goodsNamelist.value)
    };

    onMounted(() => {
        Object.assign(form, JSON.parse(sessionStorage.getItem('user')))
        getGoodsType();
        getUser()
    });
</script>

<template>
    <div class="container">
        <message v-if="open" :message=messageTo :type=type @dismiss="open = false"></message>
        <div class="top">
            <div style="display: flex; flex-wrap: nowrap; margin-top: 10px; margin-right: 20px; cursor: pointer;" @click="router.push('/home')">
                <img src="@/assets/navigation/容器(2).png" alt="" class="homeIcon" style="width: 20px; height: 20px;">
                <span style="white-space: nowrap;">商城首页</span>
            </div>
            <div class="flex1 rightBox">
                <img src="@/assets/navigation/user.png" alt="" class="userIcon">
                <div class="userStatus" v-if="userInfo.user">
                    <span class="rightSpan1">
                        欢迎您, &nbsp;&nbsp;
                        <span style="color:orangered">
                            {{ userInfo.identity === 0 ? userInfo.user.customerName : userInfo.user.managerId }}
                        </span>
                    </span>
                </div>
                <div class="userStatus" v-else>
                    <span class="rightSpan2" @click="router.push('/userLogin')">登录</span>
                    <div class="rightSplit"></div>
                    <span class="rightSpan3" @click="register">注册</span>
                </div>

                <div class="rightSplit"></div>
                <span class="rightSpan" data-bs-toggle="modal" data-bs-target="#myModal2">个人资料</span>
                <div class="rightSplit"></div>

                <span class="rightSpan" @click="router.push('/orderDetail')">订单信息</span>

                <div class="rightSplit"></div>
                <span class="rightSpan" data-bs-toggle="modal" data-bs-target="#myModal3">使用帮助</span>
                <div class="rightSplit"></div>
                <span class="rightSpan" @click="logout">注销</span>
            </div>
        </div>
        <div class="bottom flex1">
            <img class="bigIcon" src="@/assets/navigation/购物商城.png">
            <div class="typeWrapper">
                <div class="goodsType" v-for="(type, index) in goodsType" :key="index"
                     :style="type.goodsTypeName === selectedTypeIndex ? 'color:#F1652D;font-weight:600;font-size:19px;' : ''"
                     @click="selectType(type)">
                    <div>{{ type.goodsTypeName }}</div>
                </div>
                <div class="dropdown" @mouseenter="showDropdown" @mouseleave="hideDropdown">
                    <div class="moreText">
                        更多
                        <img src="@/assets/navigation/联集1(1).png" alt="" class="moreTypeIcon" v-if="showMoreType">
                    </div>
                    <div class="dropdown-menu" v-if="isOpen">
                        <div v-for="(type, index) in moreType" :key="index" @click="selectTypeDrop(type)" class="items">
                            <span>{{ type.goodsTypeName }}</span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="searchCartWrapper mx-auto">
                <div class="searchBoxWrapper">
                    <div class="searchBox">
                        <dropdownMenu :allType="allType" :production="production" @update-production="production = $event">
                        </dropdownMenu>
                        <input placeholder="请输入产品名称" v-model="production" class="searchInput">
                        <button class="searchButton" @click="toSearch">搜索</button>
                    </div>
                </div>
                <div class="cartWrapper">
                    <div class="cartBox" @click="router.push('/cart')">
                        <img src="@/assets/navigation/购物车.png" alt="">
                        <span>购物车</span>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="myModal2" class="modal">
        <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">编辑个人信息</h4>
                    <button id="btn2Close" type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <div style="display: flex; margin-left: 30px;">
                            <label for="customerName">用户名：</label>
                            <input type="text" v-model="form.customerName" class="taninput"><br><br>
                        </div>
                        <div style="display: flex; margin-left: 30px;">
                            <label for="customerPwd">密 &nbsp;&nbsp;码：</label>
                            <input type="password" v-model="form.customerPwd" class="taninput"><br><br>
                        </div>
                        <div style="display: flex; margin-left: 30px;">
                            <label for="customerAddress">住 &nbsp;&nbsp;址：</label>
                            <input type="text" v-model="form.customerAddress" class="taninput"><br><br>
                        </div>
                        <div style="display: flex; margin-left: 30px;">
                            <label for="customerPostCode">邮 &nbsp;&nbsp;编：</label>
                            <input type="text" v-model="form.customerPostCode" class="taninput"><br><br>
                        </div>
                        <div style="display: flex; margin-left: 30px;">
                            <label for="customerPhone">手机号：</label>
                            <input type="text" v-model="form.customerPhone" class="taninput"><br><br>
                        </div>
                        <div style="display: flex;margin-left: 30px;">
                            <label for="customerEmail">邮 &nbsp;&nbsp;箱：</label>
                            <input type="text" v-model="form.costomerEmail" class="taninput"><br><br>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="submit" class="btn btn-primary" @click="yes" style="margin-right: 30px;">确定</button>
                    <button type="button" class="btn btn-primary" data-bs-dismiss="modal">取消</button>
                </div>
            </div>
        </div>
    </div>

    <div id="myModal3" class="modal">
        <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">使用帮助</h4>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <div class="modal-body">
                    <div style="margin-left: 20px;">
                        <h5>1：登录</h5>
                        <p>用户需要首先登录系统，才可进行购物操作。</p>
                        <h5>2：商品首页</h5>
                        <p>用户在商品首页可以浏览商品信息，并且将其加入购物车。</p>
                        <h5>3：购物车</h5>
                        <p>用户在购物车页面，可以进行订单的确认，进行购买操作。</p>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal">关闭</button>
                </div>
            </div>
        </div>
    </div>

</template>

<style scoped>

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

    /* 订单信息 */
    .orderDetail {
        display: flex;
    }
    .items {
        cursor: pointer;
        text-align: center;
        line-height: 2;
    }
        .items:hover {
            background-color: rgb(255, 243, 226);
            color: rgb(241, 101, 45);
        }

    .dropdown {
        line-height: 2.5;
        width: 114px;
        position: relative;
    }
        .dropdown:hover .dropdown-menu {
            display: block;
        }

    .dropdown-menu {
        padding: 7px 5px;
        display: none;
        position: absolute;
        width: 80px;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        background-color: #ffffff;
        border: 1px rgb(240, 240, 240) solid;
        top: 40px;
        left: -20px;
    }

    /* 首行 */
    .top {
        top: 0;
        display: flex;
        justify-content: space-between;
        height: 40px;
        background: #F5F5F5;
    }
    .homeIcon {
        margin-left: 30px;
        margin-right: 5px;
    }
    .userIcon {
        margin-right: 5px;
    }
    .flex1 {
        display: flex;
        flex-wrap: wrap;
        align-items: center;
    }

    /*注册、登录、个人资料、订单信息、使用帮助、注销*/
    .rightSpan { margin-right: 30px; cursor: pointer; }

    /*欢迎您...*/
    .rightSpan1 {
        margin-right: 20px;
        margin-left: 10px;
    }
    .userStatus {
        display: flex;
        align-items: center;
    }
    /*登录*/
    .rightSpan2 {
        margin-right: 20px;
        margin-left: 10px;
        cursor: pointer;
    }
    /*注册*/
    .rightSpan3 {
        margin-right: 20px;
        margin-left: 2px;
        cursor: pointer;
    }
    /*首行分隔符*/
    .rightSplit {
        margin-right: 15px;
        width: 1px;
        height: 14px;
        background: #D8D8D8;
    }
    /*首行div*/
    .rightBox {
        margin-right: 20px;
    }

    /*第2行*/
    .bottom {
        padding: 10px 0;
        display: flex;
        flex-wrap: wrap;
        align-items: center;
    }
    /*购物商城图片*/
    .bigIcon {
        margin-left: 2px;
        width:140px;
        /*cursor: pointer;*/
    }
    /*购物商城图片右侧的菜单*/
    .typeWrapper {
        width: 600px;
        margin-left: 50px;
        display: flex;
        align-items: center;
        justify-content: space-between;
    }
    .goodsType {
        width: 50px;
        display: flex;
        white-space: nowrap;
        font-size: 18px;
        cursor: pointer;
    }
    .moreTypeIcon {
        width: 10px;
        height: 6px;
        margin-left: 4px;
        cursor: pointer;
    }
    .moreText {
        display: flex;
        align-items: center;
        white-space: nowrap;
        cursor: pointer;
        color: black;
        font-size: 18px;
    }

    /* 第3行 搜索 */
    .searchCartWrapper {
        margin-left: 2px;
        margin-top: -2px;
        display: flex;
        width: 600px;
        justify-content: center;
    }
    .searchBoxWrapper {
        width: 425px;
        min-width: 425px;
        height: 50px;
        opacity: 1;
        display: flex;
        align-items: center;
        cursor: pointer;
        position: relative;
    }
    .searchBox {
        display: flex;
        width: 100%;
    }
    .searchType {
        margin-left: 25px;
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
    /* 产品名称搜索框 */
    .searchInput {
        width: 200px;
        border: solid 1px;
        margin-top: 12px;
        margin-left: 10px;
        margin-right: 10px;
        padding-left: 10px;
        height: 30px;
    }
    /* 请输入产品名称右侧的搜索按钮 */
    .searchButton {
        width: 84px;
        height: 30px;
        display: flex;
        margin-top: 12px;
        align-items: center;
        justify-content: center;
        cursor: pointer;
    }
    /* 购物车图标外围div */
    .cartWrapper {
        width: 110px;
        height: 40px;
        background: #F9F7F7;
        border-radius: 4px 4px 4px 4px;
        border: 1px solid #EEEEEE;
        margin-left: 10px;
        margin-top: 5px;
        display: flex;
        justify-content: center;
        align-items: center;
        cursor: pointer;
    }
    /* 购物车图标div */
    .cartBox {
        display: flex;
        justify-content: center;
        align-items: center;
    }
        .cartBox > span {
            margin-left: 10px;
        }

    /* 个人信息 */
    label {
        display: block;
        width: 80px;
        margin-right: 10px;
        color: black;
        font-size: 20px;
        font-weight: 400;
        flex-shrink: 0;
        font-family: Microsoft Yahei;
    }
    .taninput {
        width: 300px;
        margin-bottom: 20px;
        height: 20px;
        padding: 5px;
        border: 1px solid #ccc;
        border-radius: 4px;
    }

</style>
