import { createRouter, createWebHistory } from "vue-router";

import a0 from "@/pages/Examples/ch10App.vue";
import a1 from "@/pages/Examples/E01HelloWorld.vue";
import a2 from "@/pages/Examples/E02ClickCount.vue";
import a3 from "@/pages/Examples/E03Btn.vue";
import a4 from "@/pages/Examples/E04Modal.vue";
import a5 from "@/pages/Examples/E05p-br.vue";
import a6 from "@/pages/Examples/E06ul-dl.vue";
import a7 from "@/pages/Examples/E07video.vue";
import a8 from "@/pages/Examples/E08css.vue";
import a9 from "@/pages/Examples/E09box.vue";
import a10 from "@/pages/Examples/E10selector.vue";
import a11 from "@/pages/Examples/E11Font.vue";
import a12 from "@/pages/Examples/E12WeatherForecast.vue";
import homePage from "@/pages/OnlineShop/E13HomePage.vue";
import loginPage from "@/pages/OnlineShop/E13LoginPage.vue";
import registerPage from "@/pages/OnlineShop/E13RegisterPage.vue";
import managePage from "@/pages/OnlineShop/E13ManagePage.vue";
import shoppingCart from "@/pages/OnlineShop/E13ShoppingCart.vue";
import managerLogin from "@/pages/OnlineShop/E13ManagerLogin.vue";
import orderDetail from "@/pages/OnlineShop/E13OrderDetail.vue";
const router = createRouter({
    history:createWebHistory(),
    routes: [
        { path: "/", component: a0 },
        { path: "/a1", component: a1 },
        { path: "/a2", component: a2 },
        { path: "/a3", component: a3 },
        { path: "/a4", component: a4 },
        { path: "/a5", component: a5 },
        { path: "/a6", component: a6 },
        { path: "/a7", component: a7 },
        { path: "/a8", component: a8 },
        { path: '/a9', component: a9, },
        { path: "/a10", component: a10 },
        { path: "/a11", component: a11 },
        { path: "/a12", component: a12 },

        { path: "/home", component: homePage },
        { path: '/userLogin', component: loginPage, },
        { path: '/userRegister', component: registerPage, },
        { path:'/manageLogin', component:managerLogin, },
        { path:"/manage",  component:managePage },
        { path:"/cart", component:shoppingCart },
        { path: "/orderDetail", component: orderDetail }
    ]
})
export default router;

