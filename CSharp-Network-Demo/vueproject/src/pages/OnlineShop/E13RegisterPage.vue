<script setup>
    import { useRoute, useRouter } from 'vue-router';
    import { onMounted, ref } from 'vue';
    import message from '@/components/message.vue';

    const messageTo = ref('');
    const messageOpen = ref(false);
    const messageType = ref('success');
    const close = ref(0);
    const a = ref(true);

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
    //const login = () => {
    //    if (loginForm.value.username === '' || loginForm.value.password === '') {
    //        messageFun("账号或密码不能为空", "warning");
    //    }
    //    else {
    //        fetch('/api/Customers')
    //            .then(response => response.json())
    //            .then(successResponse => {
    //                console.log(successResponse)
    //                for (let i = 0; i < successResponse.length; i++) {
    //                    if (successResponse[i].customerName === loginForm.value.username
    //                        && successResponse[i].customerPwd === loginForm.value.password) {
    //                        router.push('/home');
    //                        sessionStorage.setItem('user', JSON.stringify(successResponse[i]));
    //                        return;
    //                    }
    //                }
    //                messageFun("账号密码错误", "error");
    //            });
    //    }
    //};
    const regist = () => {
        if (form.value.customerId === "" || form.value.customerPwd === "") {
            messageFun("账号或密码不能为空", "warning");
        }
        else {
            fetch('/api/Customers')
                .then(response => response.json())
                .then(successResponse => {
                    for (let i = 0; i < successResponse.length; i++) {
                        if (successResponse[i].customerId === form.value.customerId) {
                            messageFun("该账号已存在", "warning")
                            a.value = false;
                            break;
                        }
                    }
                    if (a.value) {
                        form.value.customerRegDate = new Date();
                        fetch('/api/Customers', {
                            method: 'POST',
                            headers: {
                                'Content-Type': 'application/json'
                            },
                            body: JSON.stringify(form.value)
                        })
                            .then(() => {
                                messageFun("注册成功！", "success");
                                form.value.customerId = "";
                                form.value.customerPwd = "";
                                form.value.customerName = "";
                                form.value.customerAddress = "";
                                form.value.customerPostCode = "";
                                form.value.customerPhone = "";
                                form.value.costomerEmail = "";
                                form.value.customerRegDate = "";
                                //a.value = true;
                                router.push('/home');
                            });
                    }
                });
        }
    };
    function cancel(){
        router.push('/home');
    };
</script>

<template>
    <message v-if="messageOpen" :message=messageTo :type=messageType @dismiss="messageOpen = false" />
    <div class="container">
        <h3 class="text-center">用户注册</h3>
        <div class="mx-auto w-75">
            <div class="row">
                <label class="col-auto" for="customerId">账 &nbsp;&nbsp;号：</label>
                <input class="col-10" type="text" v-model="form.customerId">
            </div>
            <div class="row mt-3">
                <label class="col-auto" for="customerPwd">密 &nbsp;&nbsp;码：</label>
                <input class="col-10" type="password" v-model="form.customerPwd">
            </div>
            <div class="row mt-3">
                <label class="col-auto" for="customerName">用户名：</label>
                <input class="col-10" type="text" v-model="form.customerName">
            </div>
            <div class="row mt-3">
                <label class="col-auto" for="customerAddress">住 &nbsp;&nbsp;址：</label>
                <input class="col-10" type="text" v-model="form.customerAddress">
            </div>
            <div class="row mt-3">
                <label class="col-auto" for="customerPostCode">邮 &nbsp;&nbsp;编：</label>
                <input class="col-10" type="text" v-model="form.customerPostCode">
            </div>
            <div class="row mt-3">
                <label class="col-auto" for="customerPhone">手机号：</label>
                <input class="col-10" type="text" v-model="form.customerPhone">
            </div>
            <div class="row mt-3">
                <label class="col-auto" for="customerEmail">邮 &nbsp;&nbsp;箱：</label>
                <input class="col-10" type="text" v-model="form.costomerEmail">
            </div>
            <div class="mx-auto mt-3" style="width:150px">
                <button class="btn btn-primary" @click="regist">注 册</button>
                <button class="btn btn-primary" @click="cancel()" style="margin-left:20px">取 消</button>
            </div>
        </div>
    </div>

</template>

<style scoped>

</style>
