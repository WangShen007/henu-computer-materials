<script setup>
    import router from "@/router";
    import SalesList from "@/components/salesList.vue";
    import { computed, onMounted, ref } from "vue";

    const cartGoods = ref([])

    const totalPrice = computed(() => {
        let total = 0
        for (let i = 0; i < cartGoods.value.length; i++) {
            total += cartGoods.value[i].purchaseCount * cartGoods.value[i].goodsUnitPrice
        }
        return total
    })
    const subCount = (index) => {
        if (cartGoods.value[index].purchaseCount > 0)
            cartGoods.value[index].purchaseCount--
        sessionStorage.setItem('cart', JSON.stringify(cartGoods.value))
    }
    const addCount = (index) => {
        cartGoods.value[index].purchaseCount++
        sessionStorage.setItem('cart', JSON.stringify(cartGoods.value))
    }

    const getAllCartGoods = () => {
        if (sessionStorage.getItem('cart') !== null) {
            cartGoods.value = JSON.parse(sessionStorage.getItem('cart'))
        } else {
            cartGoods.value = []
        }
    }

    const emptyCart = () => {
        sessionStorage.removeItem('cart')
        getAllCartGoods()
    }

    const deleteGoods = (goods) => {
        let cart = JSON.parse(sessionStorage.getItem('cart'))

        const newCart = cart.filter((item) => {
            return item.goodsId !== goods.goodsId
        })
        sessionStorage.setItem('cart', JSON.stringify(newCart))
        getAllCartGoods()
    }

    const submitOrder = () => {
        let cart = JSON.parse(sessionStorage.getItem('cart'))
        console.log("cart", cart)
        let orderId = null
        const goodsNum = cart.length
        console.log("goodsNum", goodsNum)
        let submittedGoods = 0
        console.log("customerId", JSON.parse(sessionStorage.getItem('user')).customerId)
        console.log("orderDate", new Date().toISOString())
        console.log("totalMoney", totalPrice.value)
        fetch('/api/UserOrders', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                "customerId": JSON.parse(sessionStorage.getItem('user')).customerId,
                "orderDate": new Date().toISOString(),
                "totalMoney": totalPrice.value,
                "orderState": '0'
            })
        })
            .then(response => response.json())
            .then(data => {
                orderId = data.orderId
                for (const goods of cart) {
                    fetch('/api/OrderDetails', {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify({
                            "orderId": orderId,
                            "goodsId": goods.goodsId,
                            "goodsCount": goods.purchaseCount
                        })
                    }).then(() => {
                        submittedGoods++
                        if (submittedGoods === goodsNum) {
                            emptyCart()
                        }
                    })
                }
            })
    }

    onMounted(() => {
        getAllCartGoods()
    })

</script>

<template>
    <div class="pageWrapper">
        <div class="pageContent">
            <div class="pageRight">
                <div class="line1">
                    购物车（全部商品 &nbsp;<span style="color: #F1652D">{{ cartGoods.length }}</span>&nbsp;）
                </div>
                <div class="">
                    <div class="row line" v-for="(goods, index) in cartGoods" :key="index">
                        <div class="col-4">
                            <!--<div class="goodsImg">
                                <img :src="goods.goodsImage" alt="">
                            </div>-->
                            <div class="column1">
                                <div class="infoTitle1">{{ goods.goodsName }}</div>
                                <div class="goodsDescript">{{ goods.goodsDescript }}</div>
                            </div>
                        </div>
                        <div class="col-2">
                            <div class="infoTitle2">单价</div>
                            <div class="goodsInfo moneyNum"><span class="money">￥ </span>{{ goods.goodsUnitPrice }}</div>
                        </div>
                        <div class="col-2">
                            <div class="infoTitle2">数量</div>
                            <div class="goodsInfo countOperate">
                                <div class="operateBtn" @click="subCount(index)">-</div>
                                <input v-model="goods.purchaseCount" class="goodsCount">
                                <div class="operateBtn" @click="addCount(index)">+</div>
                            </div>
                        </div>
                        <div class="col-2">
                            <div class="infoTitle2">金额</div>
                            <div class="goodsInfo totalMoney">
                                <span class="money">￥ </span>{{ goods.goodsUnitPrice * goods.purchaseCount }}
                            </div>
                        </div>
                        <div class="col-2">
                            <div class="infoTitle2">操作</div>
                            <div class="goodsInfo operate" @click="deleteGoods(goods)">删除</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row mx-auto">
            <div class="col optionBox">
                合计：<span class="money" style="color: #F1652D">￥ </span> <span class="totalPrice"> {{ totalPrice }}</span>
                <div class="btn1" @click="submitOrder">提交订单</div>
                <div class="btn2" @click="router.push('/home')">继续购买</div>
                <div class="btn3" @click="emptyCart">清空购物车</div>
            </div>
        </div>
    </div>
</template>

<style scoped>

    .pageWrapper {
        background: #F5F5F5;
    }

    .pageContent {
        padding-top: 5px;
        padding-bottom: 5px;
        display: flex;
        margin-left: 10px;
       /* min-height: 700px;*/
    }

    .pageRight {
        margin-right: 10px;
        width: 100%;
    }

    .line1 {
        height: 72px;
        background: #FFFFFF;
        border-radius: 4px 4px 4px 4px;
        opacity: 1;
        display: flex;
        align-items: center;
        padding-left: 20px;
    }

    .line {
        display: flex;
        justify-content: space-between;
        margin-top: 10px;
        height: 132px;
        background: #FFFFFF;
        border-radius: 4px 4px 4px 4px;
        opacity: 1;
    }

    .goodsImg {
        width:60px;
        display: flex;
        align-items: center;
    }

        .goodsImg > img {
            width: 200px;
            height: 200px;
            margin-left: 20px;
        }

    .leftColumn {
        display: flex;
    }

    .column1 {
        margin-right: 24px;
        margin-left: 24px;
        margin-top: 20px;
    }

    .infoTitle1 {
        font-size: 18px;
        font-weight: 700;
        color: #333333;
        line-height: 24px;
    }

    .goodsDescript {
/*        width: 20.83vw;*/
        min-width: none;
        margin-top: 10px;
        font-size: 15px;
        font-weight: 400;
        color: #9E9E9E;
        line-height: 20px;
    }

    .infoTitle2 {
        font-size: 18px;
        font-weight: 400;
        color: #333333;
        line-height: 24px;
    }

    .colum234 {
        display: flex;
        padding-right: 60px;
    }

    .column2 {
        min-width: 61px;
        margin-top: 20px;
        text-align: center;
    }

    .money {
        font-size: 14px;
        font-weight: 400;
        color: #333333;
        line-height: 18px;
    }

    .goodsInfo {
        margin-top: 50px;
    }

    .moneyNum {
        font-size: 18px;
    }

    .column3 {
        min-width: 75px;
        margin-left: 60px;
        margin-top: 20px;
        text-align: center;
    }

    .column4 {
        min-width: 38px;
        margin-top: 20px;
        margin-left: 80px;
        text-align: center;
    }

    .totalMoney {
        font-size: 18px;
        font-weight: 700;
        color: #333333;
        line-height: 24px;
    }

    .operate {
        color: #F1652D;
        cursor: pointer;
    }

    .pageBottom {
        border-top: 1px #ececec solid;
        width: 100%;
        min-width: 1200px;
        height: 80px;
        background: #FFFFFF;
        border-radius: 4px 4px 4px 4px;
        opacity: 1;
        bottom: 0;
        position: sticky;
        text-align: right;
    }

    .optionBox {
        height: 80px;
        display: flex;
        align-items: center;
        float: right;
        margin-right: 70px;
    }

    .totalPrice {
        font-size: 18px;
        font-weight: 700;
        color: #F1652D;
        line-height: 24px;
    }

    .btn1 {
        width: 100px;
        height: 48px;
        background: #F1652D;
        border-radius: 8px 8px 8px 8px;
        opacity: 1;
        font-size: 15px;
        color: #FFFFFF;
        display: flex;
        align-items: center;
        justify-content: center;
        margin-left: 25px;
        cursor: pointer;
    }

    .btn2 {
        width: 100px;
        height: 48px;
        background: #F1652D;
        border-radius: 8px 8px 8px 8px;
        opacity: 1;
        font-size: 15px;
        color: #FFFFFF;
        display: flex;
        align-items: center;
        justify-content: center;
        margin-left: 20px;
        cursor: pointer;
    }

    .btn3 {
        width: 110px;
        height: 48px;
        border-radius: 8px 8px 8px 8px;
        opacity: 1;
        border: 1px solid #E0E0E0;
        font-size: 15px;
        color: #F1652D;
        display: flex;
        align-items: center;
        justify-content: center;
        margin-left: 20px;
        cursor: pointer;
    }

    .operateBtn {
        width: 32px;
        height: 32px;
        background: #E0E0E0;
        border-radius: 2px 0px 0px 2px;
        opacity: 1;
        cursor: pointer;
        line-height: 32px;
    }

    .goodsCount {
        width: 56px;
        height: 28px;
        opacity: 1;
        border: 1px solid #E0E0E0;
        text-align: center;
    }

    .countOperate {
        display: flex;
    }
</style>