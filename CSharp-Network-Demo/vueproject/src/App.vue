<script setup>
    import { ref } from 'vue'

    const List1 = ref([
        { title: "例10-1：HelloWorld", url: "/a1", },
        { title: "例10-2：简单组件", url: "/a2", },
        { title: "例10-3：按钮", url: "/a3", },
        { title: "例10-4：模态框", url: "/a4", },
        { title: "例10-5：段落和排版标记", url: "/a5", },
        { title: "例10-6：ul和dl标记", url: "/a6", },
        { title: "例10-7：图片和音视频标记", url: "/a7", },
        { title: "例10-8：CSS级联控制", url: "/a8", },
        { title: "例10-9：边距及盒大小", url: "/a9", },
        { title: "例10-10：基本选择器", url: "/a10", },
        { title: "例10-11：字体文本控制", url: "/a11", },
    ]);
    const List2 = ref([
        { title: "例10-12：天气预报", url: "/a12", },
        { title: "例10-13：网上商城", url: "/home", },
    ]);

    function clickItem(e) {
        var menu1 = document.getElementById("menu1");
        menu1.className = "nav-item";
        var menu2 = document.getElementById("menu2").children;
        for (let i = 0; i < menu2.length; i++) {
            menu2[i].className = 'nav-item';
        }
        var menu3 = document.getElementById("menu3").children;
        for (let i = 0; i < menu3.length; i++) {
            menu3[i].className = 'nav-item';
        }
        e.currentTarget.className = 'nav-item clicked';
    }
</script>

<template>
    <div class="container">
        <div class="row" style="margin-right:-25px ">
            <img src="@/assets/Examples/mainpage.jpg" style="height: 100px;" />
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-3">
                <div class="accordion" id="accordionMenu">
                    <div class="accordion-item">
                        <h2 class="accordion-header">
                            <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapse1" aria-expanded="true" aria-controls="collapse1">
                                第10章
                            </button>
                        </h2>
                        <div id="collapse1" class="accordion-collapse collapse" data-bs-parent="#accordionMenu">
                            <div class="accordion-body">
                                <ul>
                                    <li id="menu1" class="nav-item" @click="clickItem($event)">
                                        <div>
                                            <router-link to="/">主页</router-link>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="accordion-item">
                        <h2 class="accordion-header">
                            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapse2" aria-expanded="false" aria-controls="collapse2">
                                前端开发基础
                            </button>
                        </h2>
                        <div id="collapse2" class="accordion-collapse collapse" data-bs-parent="#accordionMenu">
                            <div class="accordion-body">
                                <ul id="menu2">
                                    <li v-for="item in List1" class="nav-item" @click="clickItem($event)">
                                        <div>
                                            <router-link :to="item.url">{{item.title}}</router-link>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="accordion-item">
                        <h2 class="accordion-header">
                            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapse3" aria-expanded="false" aria-controls="collapse3">
                                前端后端综合实例
                            </button>
                        </h2>
                        <div id="collapse3" class="accordion-collapse collapse" data-bs-parent="#accordionMenu">
                            <div class="accordion-body">
                                <ul id="menu3">
                                    <li v-for="item in List2" class="nav-item" @click="clickItem($event)">
                                        <div>
                                            <router-link :to="item.url">{{item.title}}</router-link>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="bodyContent" class="col-md-9" style="border:1px solid;">
                <router-view />
            </div>
        </div>
    </div>
</template>

<style scoped>
    li {
        list-style-type: none;
    }

    a {
        text-decoration: none;
        color: #39475A
    }

    .nav-item {
        line-height: 1.8;
        font-weight: 400;
        margin-left: -30px;
        background: #ffffff;
    }

    .clicked {
        background: #ffd800
    }
</style>