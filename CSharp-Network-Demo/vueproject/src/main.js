import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap";

import { createApp, reactive } from 'vue'
import router from './router'
import App from './App.vue'

const app = createApp(App)
const globalData = reactive({
    globalVariable: {
        goodsTypeId: 0,
        goodsTypeName: "全部类型"
    },
});
const searchData = reactive({
    globalVariable: {
        data: "",
        flag: false
    },
});
app.provide('$globalData', globalData);
app.provide('$searchData', searchData);
app.use(router)
app.mount('#app')
