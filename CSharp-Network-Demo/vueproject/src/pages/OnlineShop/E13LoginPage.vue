<script setup>
    import { useRoute, useRouter } from 'vue-router';
    import { onMounted, ref } from 'vue';
    import message from '@/components/message.vue';

    const messageTo = ref('');
    const messageOpen = ref(false);
    const messageType = ref('success');
    const a = ref(true);
    const loginForm = ref({
        username: '',
        password: ''
    });

    const form = ref({
        customerId: "",
        customerPwd: "",
        customerName: "",
        customerAddress: "",
        customerPostCode: "",
        customerPhone: "",
        costomerEmail: "",
        customerRegDate: ""
    });
    const messageFun = (messageNeed, typeNeed) => {
        messageOpen.value = true;
        messageTo.value = messageNeed;
        messageType.value = typeNeed;
        setTimeout(() => {
            messageOpen.value = false;
        }, 5000);
    };
    const router = useRouter();
    const login = () => {
        if (loginForm.value.username === '' || loginForm.value.password === '') {
            messageFun("账号或密码不能为空", "warning");
        }
        else {
            fetch('/api/Customers')
            .then(response => response.json())
            .then(successResponse => {
                console.log(successResponse)
                for (let i = 0; i < successResponse.length; i++) {
                    if (successResponse[i].customerName === loginForm.value.username
                        && successResponse[i].customerPwd === loginForm.value.password) {
                        sessionStorage.setItem('user', JSON.stringify(successResponse[i]));
                        router.push('/home');
                        return;
                    }
                }
                messageFun("账号密码错误", "error");
            });
        }
    };
</script>

<template>
    <message v-if="messageOpen" :message=messageTo :type=messageType @dismiss="messageOpen = false" />
    <div class="mx-auto w-50">
        <h4 class="mt-5 text-center">用户登录</h4>
        <div class="row mt-5">
            <div class="col-auto">
                <img src="/src/assets/login/t1.png" alt="t1">
            </div>
            <input class="col-10" type="text" v-model="loginForm.username" placeholder="用户名">
        </div>
        <div class="row mt-4">
            <div class="col-auto">
                <img src="/src/assets/login/t2.png" alt="t2">
            </div>
            <input class="col-10" type="password" v-model="loginForm.password" placeholder="密码">
        </div>
        <div class="row mt-4 mb-4">
            <button class="col-6 offset-3 btn btn-primary mt-3" @click="login">登 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;录</button>
        </div>
    </div>
</template>

<style scoped>

</style>
