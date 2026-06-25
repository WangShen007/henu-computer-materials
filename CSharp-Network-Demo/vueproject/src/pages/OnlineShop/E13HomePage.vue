<script setup>
    import NavigationBar from "@/components/navigationBar.vue";
    import message from "@/components/message.vue";
    import pagination from "@/components/pagination.vue";
    import SalesList from "@/components/salesList.vue";
    import { onMounted, reactive, ref, watch, inject } from "vue";
    import router from "@/router";

    const globalData = inject('$globalData');
    const searchData = inject('$searchData');
    watch(globalData, (newVal) => {
        getGoods();
    });
    watch(searchData, (newVal) => {
        searchGoods(newVal.globalVariable.data);
    });

    //【显示/隐藏】消息框message（登录、注册）
    const open = ref(false)
    const messageTo = ref("")
    const type = ref("success")
    const messageFun = (messageNeed, typeNeed) => {
        open.value = true
        messageTo.value = messageNeed
        type.value = typeNeed
        setTimeout(() => {
            open.value = false
        }, 5000);
    }

    //搜索商品
    const searchGoods = (sData) => {
        fetch('/api/Goods')
            .then(r => r.json())
            .then(res => {
                console.log(res)
                if (globalData.globalVariable.goodsTypeId != 0) {
                    let temp = []
                    for (let i of res) {
                        if (i.goodsTypeId == globalData.globalVariable.goodsTypeId) {
                            temp.push(i)
                        }
                    }
                    temp = temp.filter(item => item.goodsName.includes(sData))
                    allGoods.value = temp
                }
                else {
                    allGoods.value = res.filter(item => item.goodsName.includes(sData))
                }
                const currentPage = allGoods.value.slice(0, 9)
                first4Items.value = currentPage.slice(0, 9)

                let allGoodsNoImg = []
                for (let re of res) {
                    const goodsNoImg = { ...re }
                    delete goodsNoImg.goodsImage
                    allGoodsNoImg.push(goodsNoImg)
                }
                sessionStorage.setItem('allGoodsNoImg', JSON.stringify(allGoodsNoImg))
                return;
            });
    }

    //获取商品
    const allGoods = ref([])
    const first4Items = ref([])
    const getGoods = () => {
        fetch('/api/Goods')
        .then(r => r.json())
        .then(res => {
            console.log(res)
            if (globalData.globalVariable.goodsTypeId != 0) {
                let temp = []
                for (let i of res) {
                    if (i.goodsTypeId == globalData.globalVariable.goodsTypeId) {
                        temp.push(i)
                    }
                }
                allGoods.value = temp
            }
            else {
                allGoods.value = res
            }
            const currentPage = allGoods.value.slice(0, 9);
            first4Items.value = currentPage.slice(0, 9);

            let allGoodsNoImg = [];
            for (let re of res) {
                const goodsNoImg = { ...re }
                delete goodsNoImg.goodsImage
                allGoodsNoImg.push(goodsNoImg)
            }
            sessionStorage.setItem('allGoodsNoImg', JSON.stringify(allGoodsNoImg));
            return;
        });
    }
    onMounted(() => {
        getGoods()
    })

    const form = reactive({
        "goodsId": 1,
        "goodsName": "",
        "goodsTypeId": 0,
        "goodsDescript": "",
        "goodsUnitPrice": 0,
        "goodsImage": '',
        "sellCount": 1,
        "goodsDate": "2023-09-30T00:00:00"
    });

    //单击商品时，给显示的模态框赋值
    const clickGoods = (goods) => {
        Object.assign(form, goods);
    }

    //添加到购物车
    function addToCart(){
        document.getElementById('homeBtn1Close').click();
        const goods = { ...form };
        if (sessionStorage.getItem('cart') != null) {
            let oldCart = JSON.parse(sessionStorage.getItem('cart'))
            for (let i = 0; i < oldCart.length; i++) {
                if (oldCart[i].goodsId === goods.goodsId) {
                    oldCart[i].purchaseCount++;
                    sessionStorage.setItem('cart', JSON.stringify(oldCart));
                    alert("加入购物车成功。");
                    return;
                }
            }
            goods.purchaseCount = 1;
            oldCart.push(goods);
            sessionStorage.setItem('cart', JSON.stringify(oldCart));
        } else {
            goods.purchaseCount = 1;
            sessionStorage.setItem('cart', JSON.stringify([goods]));
            alert("加入购物车成功。");
        }
    }

    //换页
    const handleCurrentChange = (val) => {
        const currentPage = allGoods.value.slice((val - 1) * 9, val * 9)
        first4Items.value = currentPage.slice(0, 9)
    }
</script>

<template>
    <navigation-bar></navigation-bar>
    <div class="pageWrapper">
        <message v-if="open" :message=messageTo :type=type @dismiss="open=false"></message>
        <div class="pageContent">
            <div class="line1">
                <sales-list />
                <div v-for="(goods, index) in first4Items" :key="index"
                     class="goodsInfo" @click="clickGoods(goods)" data-bs-toggle="modal" data-bs-target="#homeModal">
                    <img :src="goods.goodsImage" alt="">
                    <div class="goodsName">{{ goods.goodsName }}</div>
                    <div class="goodsDescript"> {{ goods.goodsDescript }}</div>
                    <div class="goodsUnitPrice"><span>￥</span>{{ goods.goodsUnitPrice }}</div>
                </div>
                <div style="width: 500px; padding-left: 50px;" v-if="allGoods.length == 0">
                    未查询到商品！如果服务器尚未完全启动，请等待片刻...
                </div>
            </div>
            <div class="pagination">
                <pagination :pageSize="9" :total="allGoods.length" @current-change="handleCurrentChange"></pagination>
            </div>
            <div class="managerLogin" @click="router.push('/manageLogin')">
                管理入口
            </div>
            <div class="CopyRight">
                CopyRight@2023 All Right Reserved
            </div>
        </div>
    </div>

    <!--正常宽度（默认），超大宽度（modal-xl），较大宽度（modal-lg），较小宽度（modal-sm）-->
    <div class="modal modal-lg" id="homeModal">
        <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">查看商品</h4>

                    <!--注意：由于navigation-bar也在此页中，一定要确保下面的id不要和navigation-bar中的id重名-->
                    <button id="homeBtn1Close" type="button" class="btn-close" data-bs-dismiss="modal"></button>

                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <span class="col-auto" border>商品名称</span>
                            <input type="text" class="col-6 border" v-model="form.goodsName" disabled>
                            <span class="col-auto border">商品类别</span>
                            <input type="text" class="col-2 border" v-model="form.goodsTypeId" disabled>
                        </div>
                        <div class="row mt-3">
                            <div class="col-auto">商品描述</div>
                            <textarea type="text" class="col-10" v-model="form.goodsDescript" disabled />
                        </div>
                        <div class="row mt-3">
                            <span class="col-auto">商品单价</span>
                            <input type="text" class="col-10" v-model="form.goodsUnitPrice" disabled>
                        </div>
                        <div class="row">
                            <div class="col-auto">商品图片</div>
                            <img :src="form.goodsImage" class="col-10" alt="">
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="submit" class="btn btn-primary" @click="addToCart()" style="margin-right: 30px;">加入购物车</button>
                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal">关闭</button>
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped>

/*    .dialog-width {
        width: 800px;
        display: flex;
    }*/

    .pageWrapper {
        background: #F5F5F5;
        display: flex;
        justify-content: center;
    }
    .pageContent {
        padding-top: 5px;
        padding-bottom: 5px;
    }
    .line1 {
        display: flex;
        flex-wrap: wrap;
        justify-content: center;
    }
    .goodsInfo {
        width: 140px;
        height: 250px;
        background: #FFFFFF;
        border-radius: 4px 4px 4px 4px;
        opacity: 1;
        margin-bottom: 10px;
        margin-right: 5px;
        text-align: center;
        cursor: pointer;
    }
        .goodsInfo > img {
            margin-top: 5px;
            width: 100px;
            height: 100px;
        }
    .goodsName {
        text-align: left;
        margin-left: 15px;
        font-size: 14px;
        font-weight: 300;
        color: #333333;
        line-height: 20px;
    }
    .goodsDescript {
        text-align: left;
        margin-left: 0;
        margin-top: 5px;
        font-size: 12px;
        font-weight: 200;
       /* color: #9E9E9E;*/
        line-height: 20px;
    }
    .goodsUnitPrice {
        text-align: left;
        margin-left: 20px;
        margin-top: 10px;
        font-size: 16px;
        font-weight: 300;
        color: #F1652D;
        line-height: 20px;
    }
    .goodsUnitPrice > span {
        font-size: 12px;
        font-weight: 300;
        color: #F1652D;
        line-height: 18px;
    }

    /* 分页 */
    .pagination {
        margin-top: 5px;
        display: flex;
        justify-content: center;
    }
    /* 管理入口 */
    .managerLogin {
        margin-top: 5px;
        text-align: center;
        cursor: pointer;
    }
    .CopyRight {
        margin-top: 10px;
        text-align: center;
        font-size: 14px;
        font-weight: 400;
        color: #9E9E9E;
        line-height: 18px;
    }

    .line4 {
        margin-top: 36px;
        padding-left: 10px;
    }


    .goodName {
        font-size: 16px;
        font-weight: 400;
       /* color: #333333;*/
        line-height: 21px;
    }

    .goodType {
        font-size: 16px;
        font-weight: 400;
        /*color: #333333;*/
        line-height: 21px;
        margin-left: 80px;
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
        padding-left: 20px;
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

/*    .goodshow {
        font-size: 16px;
        font-weight: 400;
        color: #333333;
    }*/

/*    .goodshowinput {
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
    }*/

/*    .goodmuch {
        font-size: 16px;
        font-family: Microsoft YaHei-Regular, Microsoft YaHei;
        font-weight: 400;
        color: #333333;
        line-height: 21px;
    }*/

/*    .goodmuchinput {
        margin-left: 20px;
        padding-left: 20px;
        width: 300px;
        height: 32px;
        border: 1px solid #E0E0E0;
        outline: none;
    }*/

/*    .save {
        position: absolute;
        bottom: 20px;
        left: 710px;
        width: 120px;
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

/*    .cancel {
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

</style>
