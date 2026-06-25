<!--<script setup>
    import { ref } from 'vue'
</script>-->

<template>
    <div class="row" style="margin-top:10px;">
        <div class="col-md-5">
            <h6>img基本用法</h6>
            <img src="/src/assets/Examples/pic1.jpg" style="width:50%"
                 class="img-thumbnail" alt="缩略图">
            <h6>audio基本用法</h6>
            <audio id="audio2" src="/src/assets/Examples/dj.mp3"
                   controls="controls"></audio>
        </div>
        <div class="col-md-7">
            <h6>video基本用法</h6>
            <video id="video2" src="/src/assets/Examples/wildlife.mp4" style="width:450px"
                   loop="loop" controls="controls"></video>
        </div>
    </div>
</template>
