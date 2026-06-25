<script setup>
    import { ref } from 'vue'
</script>

<template>
    <h3>排版标记示例</h3>
    <h5>李白<small>唐代著名诗人</small></h5>
    <p>唐代有很多著名诗人，<span class="lead">李白</span>是其中的一位。</p>
    <p class="text-center"> 第10章 Vue和ASP.NET Core Web API（居中：text-center）</p>
    <hr style="height:5px; background-color:blue;" />
    <p>你<b>终于</b>明白<i><u>不吃饭</u></i>和<i><u>不想吃饭</u></i>不是一回事了。</p>
    <p>这是 <i><b>斜体加粗</b></i> 的效果</p>
    <p>sup标记： 2<sup>3</sup> × 3 = 24;</p>
    <p>sub标记：鱼儿离不开水（H<sub>2</sub>O）。</p>
</template>

<style>

</style>
