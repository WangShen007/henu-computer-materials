<script setup>
    import { ref } from 'vue'

    const active1Class = ref('active1');
    const active2Class = ref('active2');

    function toggleClass1() {
        active1Class.value = active1Class.value == "active1" ? "" : "active1";
    }
    function toggleClass2() {
        active2Class.value = active2Class.value == "active2" ? "" : "active2";
    }

</script>

<template>
    <br />
    <h2>基本选择器的用法</h2>
    <div class="mydiv">
        <p id="p1" :class="{active1: active1Class }">这是p元素(id="p1")</p>
        <p id="p2" :class="{active1: active1Class }">这是p元素(id="p2")</p>
        <div id="div1" :class="{demo1:active2Class}">这是div1(id="div1",class="demo1")</div>
        <div id="div2" :class="{demo1:active2Class}">这是div2(id="div2",class="demo1")</div>
    </div>
    <hr />
    <button class="btn btn-primary" @click="toggleClass1" style="margin-right:10px;">切换p元素的前景和背景色</button>
    <button class="btn btn-primary" @click="toggleClass2">切换demo1的前景和背景色</button>
</template>

<style scoped>
    .active1 {
        background-color: green;
        color: white;
    }
    .active2 {
        background-color: red;
        color: white;
    }

    .mydiv {
        margin: 15px auto;
        padding: 2px;
        border: 1px solid #ccc;
    }

    .demo1 {
        border-radius: 15px;
        margin: 15px auto;
        width: 280px;
        height: 30px;
        border: 1px solid blue;
    }

</style>

