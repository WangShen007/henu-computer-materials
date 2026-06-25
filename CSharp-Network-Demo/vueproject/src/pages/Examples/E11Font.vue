<script setup>
    import { ref } from 'vue'

    const str0 = "朝辞白帝彩云间，千里江陵一日还。";
    const str1 = "朝辞白帝彩云间，千里江陵一日还。两岸猿声啼不住，轻舟已过万重山。";

</script>

<template>
    <h4>（1）字体控制</h4>
    <p style="font:16px; font-weight:500;">{{str1}}</p>
    <p class="a1">{{str0}}</p>
    <h4>（2）文本控制</h4>
    <div class="a0 a2">
        <p>{{str1}}{{str1}}{{str1}}</p>
        <p class="a3 btn-success">{{str1}}{{str1}}</p>
        <p style="letter-spacing:6px;">{{str1}}</p>
    </div>
</template>

<style scoped>
    .a0 {
        border: 1px dashed blue;
    }

    .a1 {
        font-family: STCaiyun;
        font-weight: 500;
        font-size: 43px;
        background-image: linear-gradient(to top, red, yellow, green);
    }

    .a2 {
        font-family: FangSong;
        text-indent: 30px;
        line-height: 30px;
    }

    .a3 {
        overflow: hidden;
        width: 350px;
        white-space: nowrap;
        text-overflow: ellipsis;
    }

</style>