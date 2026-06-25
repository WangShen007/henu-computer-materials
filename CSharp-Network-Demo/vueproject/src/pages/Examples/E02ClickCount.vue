<script setup>
    import { ref, onMounted } from 'vue';
    // 响应式状态
    const count1 = ref(0);
    const count2 = ref(0);
    // 修改状态、触发更新的函数
    function increment() { count2.value++ };
    // 生命周期钩子
    onMounted(() => {
        console.log(`count1初值为：${count1.value}.`);
        console.log(`count2初值为：${count2.value}.`);
    });
</script>

<template>
    <div class="row mt-3">
        <div class="col-md-8">
            <button class="btn btn-primary" @click="count1++">用法1：单击按钮让Count1的值加1</button>
            <span>Count1的值为：{{ count1 }}</span>
        </div>
    </div>
    <div class="row mt-3">
        <div class="col-md-8">
            <button class="btn btn-primary" @click="increment">用法2：单击按钮让Count2的值加1</button>
            <span>Count2的值为：{{ count2 }}</span>
        </div>
    </div>
</template>

<style scoped>
    button {
        font-weight: bold;
    }
</style>

