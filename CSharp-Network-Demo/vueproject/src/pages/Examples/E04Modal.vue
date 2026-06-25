<script setup>
    import { ref } from 'vue';
    import vueModal from '@/components/vueModal.vue';
    const showModal = ref(false);
</script>

<template>
    <div class="container mt-3">
        <h5>水平和垂直方向都居中显示，且自适应屏幕大小的Vue模态框</h5>
        <h6>Vue模态框必须以组件的形式单独提供</h6>
        <button class="btn btn-info" @click="showModal=true">显示Vue模态框</button>
        <Teleport to="body">
            <vueModal :show="showModal" @close="showModal=false">
                <template #header>
                    <h3>自定义 header</h3>
                </template>
                <template #body>
                    <h3>自定义 body</h3>
                    模态框内容1
                    <br />
                    模态框内容2
                </template>
                <template #footer>
                    <button class="btn btn-primary" @click="showModal=false">取消</button>
                </template>
            </vueModal>
        </Teleport>

        <h5 style="margin-top:20px;">水平和垂直方向都居中显示，且自适应屏幕大小的Bootstrap模态框</h5>
        <h6>Bootstrap模态框不需要以组件的形式单独提供</h6>
        <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#myModal">
            显示Bootstrap模态框
        </button>
    </div>

    <!-- bootstrap模态框 -->
    <div class="modal" id="myModal">
        <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">模态框标题</h4>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <div class="modal-body">
                  模态框内容1<br />
                  模态框内容2<br />
                  模态框内容3<br />
                  模态框内容4<br />
                  模态框内容5<br />
                  模态框内容6<br />
                  模态框内容7<br />
                  模态框内容8<br />
                  模态框内容9<br />
                  模态框内容10<br />
                  模态框内容11<br />
                  模态框内容12<br />
                  模态框内容13<br />
                  模态框内容14<br />
                  模态框内容15<br />
                  模态框内容16<br />
                  模态框内容17<br />
                  模态框内容18<br />
                  模态框内容19<br />
                  模态框内容20<br />
                  模态框内容21<br />
                  模态框内容22<br />
                  模态框内容23<br />
                  模态框内容24<br />
                  模态框内容25<br />
                  模态框内容26<br />
                  模态框内容27<br />
                  模态框内容28<br />
                  模态框内容29<br />
                  模态框内容30<br />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal">关闭</button>
                </div>
            </div>
        </div>
    </div>
</template>

<style>

</style>
