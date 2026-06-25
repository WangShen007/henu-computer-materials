<script setup>
    import { ref } from 'vue'

    const message = ref('Hello World!');
    const obj = ref({
        nested: { count: 0 },
        arr: ['foo', 'bar']
    });

    const isRed = ref(true)
    const color = ref('green')

    function toggleRed() {
        isRed.value = !isRed.value
    }
    function toggleColor() {
        color.value = color.value === 'green' ? 'blue' : 'green'
    }
</script>

<template>
    <div class="bg-primary text-white" style="margin:10px 0">
        <h6>注意：</h6>
        在VS2022中添加一个vue文件时，先在备选模板中选择添加【HTML文件】，注意此时不要修改扩展名。添加后，再将其扩展名改为“.vue”，这可以避免中文乱码。
    </div>
    <h3>message：{{ message }}</h3>
    <div>
        “ref”是存储值的响应式数据源（reactive data source）。
        从技术上讲，不需要为了显示字符串用ref()来包装，但如果要动态更改字符串的值，此时就用到ref()了。
    </div>
    <br />
    <div>
        下面是深层ref的响应结果：
    </div>
    <h3>obj.nested.count：{{ obj.nested.count }}</h3>
    <h3>obj.arr[0]：{{ obj.arr[0] }}</h3>
    <h3>obj.arr[1]：{{ obj.arr[1] }}</h3>
    <br />
    <!-- 除了普通字符串之外，v-bind:class还支持绑定对象和数组【:class是v-bind:class的简写】 -->
    <p :class="{ red: isRed }" @click="toggleRed">
        该行用class声明为判断是否为red... 用click事件切换颜色（单击一下本行看看切换【红色/黑色】的效果）。
    </p>

    <!-- 样式绑定【v-bind:style】也支持对象和数组 -->
    <p :style="{ color }" @click="toggleColor">
        该行应该是绿色，单击可切换【绿色/蓝色】。
    </p>
</template>

<style>
    .red {
        color: red;
    }
</style>