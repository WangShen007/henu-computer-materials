<script setup>
    import { ref } from 'vue';

    //外部链接式
    import "@/assets/ch10style.css";
</script>

<template>
    <h2 class="bg-success  text-white text-center" style="margin-top:20px;">CSS级联控制的基本用法</h2>

    <!--内联式-->
    <p style="font-size: 20pt; color: green;">Hello，张三</p>

    <!--级联控制-->
    <p class="style1" style="color: green;">Hello，李四</p>
    <div class="center-block style2 style3" style="width: 200px; height: 80px;">
        这是div
    </div>
</template>

<style scoped>
    /*嵌入式*/
    .style3 {
        border-width: 20px;
        border-color: Red;
    }
</style>

