<script setup>
    import { ref, onMounted } from 'vue';

    const goodsSales = ref([]);
    const getSalesList = () => {
        const getRank = setInterval(() => {
            if (sessionStorage.getItem('allGoodsNoImg') !== null) {
                const allGoodsNoImg = JSON.parse(sessionStorage.getItem('allGoodsNoImg'));
                goodsSales.value = allGoodsNoImg
                    .sort((a, b) => b.sellCount - a.sellCount)
                    .slice(0, 5);
                clearInterval(getRank);
            }
        }, 300);
    };
    onMounted(() => {
        getSalesList();
    });
</script>

<template>
    <div>
        <div class="listWrapper">
            <div class="line1">
                <img src="@/assets/salesList/销售排行榜.png" alt="">
                <span class="type">电脑</span>
            </div>
            <div class="lineWrapper" v-for="(goods, index) in goodsSales" :key="index">
                <span style="font-size: large;font-weight: 600;color: rgb(232, 89, 17);">{{ index + 1 }}</span>
                <span style="font-size: 15px;">{{goods.goodsName}}</span>
            </div>
        </div>
    </div>
</template>

<style scoped>
    .listWrapper {
        margin-right: 5px;
        width: 235px;
        height: 250px;
        background: #FFFFFF;
        border-radius: 4px 4px 4px 4px;
        opacity: 1;
    }
    .line1 {
        padding-top: 15px;
        margin-left: 5px;
        margin-bottom: 5px;
        display: flex;
        align-items: center;
    }
    .type {
        margin-left: 10px;
        color: #F1652D;
    }
    .lineWrapper {
        margin-left: 10px;
        margin-top: 10px;
        width: 224px;
        height: 32px;
        background: linear-gradient(90deg, rgba(149, 149, 149, 0.13) 0%, rgba(255, 145, 83, 0) 100%);
        border-radius: 580px;
        opacity: 1;
        display: flex;
        align-items: center;
    }
        .lineWrapper > span {
            margin-left: 20px;
        }
</style>