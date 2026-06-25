<script setup>
    import { ref } from 'vue'
    function showAlert() {
        alert('ok');
    }
</script>

<template>
    <div class="container mt-3">
        <h2>按钮样式</h2>
        <button type="button" class="btn btn-primary" @click="showAlert">主要按钮</button>
        <button type="button" class="btn btn-secondary" @click="showAlert">次要按钮</button>
        <button type="button" class="btn btn-success" @click="showAlert">成功</button>
        <button type="button" class="btn btn-info" @click="showAlert">信息</button>
        <button type="button" class="btn btn-warning" @click="showAlert">警告</button>
        <button type="button" class="btn btn-danger" @click="showAlert">危险</button>
        <button type="button" class="btn btn-dark" @click="showAlert">黑色</button>
        <button type="button" class="btn btn-light" @click="showAlert">浅色</button>
        <button type="button" class="btn btn-link" @click="showAlert">链接</button>
    </div>
</template>

<!--<style scoped>
    button {
        margin-top: 10px;
        font-weight: bold;
    }
</style>-->
