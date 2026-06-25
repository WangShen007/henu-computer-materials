<script setup>
    import { useRoute, useRouter } from 'vue-router';
    import { onMounted, ref } from 'vue';
    import message from '@/components/message.vue';

    const messageTo = ref('');
    const open = ref(false);
    const type = ref('success');
    const dialogVisible = ref(false);
    const a = ref(true);
    const loginForm = ref({
        username: '',
        password: ''
    });
    const messageFun = (messageNeed, typeNeed) => {
        open.value = true;
        messageTo.value = messageNeed;
        type.value = typeNeed;
        setTimeout(() => {
            open.value = false;
        }, 3000);
    };
    const router = useRouter();
    const login = () => {
        if (loginForm.value.username === '' || loginForm.value.password === '') {
            messageFun("账号或密码不能为空", "warning");
        } else {
            fetch('/api/Managers')
                .then(response => response.json())
                .then(successResponse => {
                    for (let i = 0; i < successResponse.length; i++) {
                        if (successResponse[i].managerId === loginForm.value.username
                            && successResponse[i].managerPwd === loginForm.value.password) {
                            sessionStorage.setItem('manager', JSON.stringify(successResponse[i]));
                            router.push('/manage');
                            this.messageFun("登录成功", "success");
                            return;
                        }
                    }
                    messageFun("账号密码错误。注意：只有管理员才能进入【管理入口】！", "error");
                });
        }
    };
    onMounted(() => {
        const route = useRoute()
        dialogVisible.value = route.query.register
    });
</script>

<template>
    <div style="  position: relative">
        <message v-if="open" :message=messageTo :type=type @dismiss="open = false"></message>
        <div class="core">
            <div class="logindiv">
                <span class="loginTitle">管理员登录</span>
                <div class="uername">
                    <div>
                        <img src="@/assets/login/t1.png" alt="" class="uernameimg">
                    </div>
                    <input type="text" class="inputuername" v-model="loginForm.username" placeholder="用户名">
                </div>
                <div class="password">
                    <div>
                        <img src="@/assets/login/t2.png" alt="" class="uernameimg">
                    </div>
                    <input type="password" class="inputuername" v-model="loginForm.password" placeholder="密码">
                </div>
                <div class="yes" @click="login" style="cursor:pointer;">
                    <span class="denglu">登 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 录</span>
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped>
    .logindiv {
        position: relative;
        float: right;
        margin-right: 180px;
        top: 0;
        width: 480px;
        height: 370px;
        background: #FFFFFF;
        border-radius: 5px;
    }

    .yes {
        position: relative;
        left: 11%;
        top: 160px;
        width: 360px;
        height: 40px;
        background: #F1652D;
        border-radius: 5px 5px 5px 5px;
        opacity: 1;
    }

    .loginTitle {
        display: flex;
        justify-content: center;
        position: relative;
        top: 30px;
        font-size: 23px;
        font-weight: 400;
        color: #333333;
        line-height: 32px;
    }

    .denglu {
        display: flex;
        justify-content: center;
        position: relative;
        top: 10px;
        font-size: 13px;
        font-weight: 400;
        color: #FFFFFF;
        line-height: 20px;
        text-align: center;
    }

    .uername {
        position: relative;
        left: 11%;
        min-width: 150px;
        max-width: 369px;
        top: 70px;
        height: 50px;
        border-radius: 8px 8px 8px 8px;
        opacity: 1;
        border: 1px solid #E0E0E0;
    }

    .password {
        position: relative;
        left: 11%;
        min-width: 150px;
        max-width: 369px;
        top: 110px;
        height: 50px;
        border-radius: 8px 8px 8px 8px;
        opacity: 1;
        border: 1px solid #E0E0E0;
    }

    .uernameimg {
        position: absolute;
        left: 13px;
        top: 12px;
        width: 24px;
        height: 24px;
    }

    .inputuername {
        position: absolute;
        left: 50px;
        width: 10vw;
        height: 45px;
        border: none;
        outline: none;
    }

    ::placeholder {
        color: #999999;
        font-size: 15px;
    }
</style>