<!--<script setup>
    import { ref } from 'vue'
</script>-->

<template>
    <h6>ul基本用法</h6>
    <div class="row">
        <div class="col-md-4">
            <h6 class="bg-primary text-white">（1）默认样式</h6>
            <ul>
                <li>子项1</li>
                <li>子项2</li>
                <li>子项3</li>
            </ul>
        </div>
        <div class="col-md-8">
            <h6 class="bg-primary text-white">（2）Bootstrap列表</h6>
            <ul class="list-group">
                <li class="list-group-item">子项1</li>
                <li class="list-group-item">子项2</li>
                <li class="list-group-item">子项3</li>
            </ul>
        </div>
    </div>
    <h6>dl基本用法</h6>
    <p class="bg-primary text-white">基本用法--每项及其描述纵向堆叠</p>
    <dl>
        <dt>子项1</dt>
        <dd>子项1的描述信息。另外，当每一项的描述信息太长时（超出可显示的最大宽度），这种排列方式还会自动换行；当窗口变得很窄时，它还会自动变为默认的纵向堆叠方式。</dd>
        <dt>子项2</dt>
        <dd>子项2的描述信息。</dd>
    </dl>
</template>

<!--<style>
</style>-->