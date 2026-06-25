<script setup>
    import { onMounted, ref, inject } from "vue";

    const UserOrders = ref([])
    const goods = ref([])
    const globalData = inject('$globalData');
    const orderdetail = () => {
        fetch('/api/UserOrders')
            .then(response => response.json())
            .then(res => {
                UserOrders.value = res
            })
    }
    const OrderDetails = ref([])
    const getGoods = (id) => {
        goods.value = []
        //console.log(id)
        fetch('/api/OrderDetails')
            .then(r => r.json())
            .then(res => {
                for (let i of res) {
                    if (i.orderId == id) {
                        fetch('/api/Goods/' + i.goodsId)
                            .then(r => r.json())
                            .then(result => {
                                let temp = {
                                    "goodsImage": "string",
                                    "goodsUnitPrice": 0,
                                    "goodsDescript": "string",
                                    "goodsName": "string",
                                    "goodsCount": "goodsCount"
                                }
                                temp.goodsCount = i.goodsCount
                                temp.goodsImage = result.goodsImage
                                temp.goodsUnitPrice = result.goodsUnitPrice
                                temp.goodsName = result.goodsName
                                temp.goodsDescript = result.goodsDescript
                                goods.value.push(temp)
                                //console.log(goods.value)
                                temp.goodsDetail = goods.value
                            });
                    }
                }
            })
    }
    onMounted(() => {
        orderdetail()
    })
</script>

<template>
    <div class="pageWrapper">
        <div class="pageContent">
            <div class="pageRight">
                <div class="line1">
                    订单信息（全部订单 &nbsp;<span style="color: #F1652D">{{ UserOrders.length }}</span>&nbsp;）
                </div>
                <table class="bordered-table">
                    <thead>
                        <tr>
                            <th>订单编号</th>
                            <th>订单日期</th>
                            <th>订单金额</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="item in UserOrders" :key="item.orderId">
                            <td style="cursor: pointer;" @click="getGoods(item.orderId)"
                                data-bs-toggle="modal" data-bs-target="#myModal4">
                                {{ item.orderId }}（点击查看详情）
                            </td>
                            <td>{{ item.orderDate }}</td>
                            <td>{{ item.totalMoney }}</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <div id="myModal4" class="modal modal-xl">
        <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">订单详情</h4>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <div class="modal-body">
                    <div style="margin: 20px 10px">
                        <table class="bordered-table">
                            <thead>
                                <tr>
                                    <th>图片</th>
                                    <th>名称</th>
                                    <th>描述</th>
                                    <th>单价</th>
                                    <th>数量</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="item in goods">
                                    <td><img :src="item.goodsImage" alt="" style="width: 100px;height: 100px;margin-left: 20px;"></td>
                                    <td>{{ item.goodsName }}</td>
                                    <td>{{ item.goodsDescript }}</td>
                                    <td>{{ item.goodsUnitPrice }}</td>
                                    <td>{{ item.goodsCount }}</td>
                                </tr>
                            </tbody>
                        </table>
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
    .pageWrapper {
        background: #F5F5F5;
    }

    .pageContent {
        padding-top: 30px;
        padding-bottom: 50px;
        display: flex;
        margin-left: 70px;
        min-height: 300px;
    }

    .pageRight {
        margin-right: 70px;
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
            background-color: coral;
        }
</style>