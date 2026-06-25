<script setup>
    import { ref, inject, watch } from 'vue';
    const globalData = inject('$globalData');
    const isOpen = ref(false);
    const currentType = ref("全部类型");
    const props = defineProps(['allType', 'production']);
    function handleClick(type, index) {
        currentType.value = props.allType[index].goodsTypeName;
        globalData.globalVariable = type
        isOpen.value = false;
    }
    function showDropdown() {
        isOpen.value = true;
    }
    watch(globalData, (newVal) => {
        currentType.value = newVal.globalVariable.goodsTypeName
    });
    function hideDropdown() {
        isOpen.value = false;
    }
</script>

<template>
    <div class="dropdown" @mouseenter="showDropdown" @mouseleave="hideDropdown">
        <div class="currentType">
            {{ currentType }}<img src="@/assets/navigation/联集1.png" alt="" class="searchTypeMoreIcon">
        </div>

        <div class="dropdown-menu" v-if="isOpen">
            <div v-for="(type, index) in allType" :key="index" @click="handleClick(type, index)" class="items">
                <span> {{ type.goodsTypeName }} </span>
            </div>
        </div>
    </div>
</template>

<style scoped>
    .searchTypeMoreIcon {
        width: 15px;
        height: 8px;
        margin-left: 10px;
    }

    .currentType {
        margin-left: 25px;
        line-height: 52px;
        text-align: center;
    }

    .items {
        cursor: pointer;
        text-align: center;
        line-height: 2;
    }

        .items:hover {
            background-color: rgb(255, 243, 226);
            color: rgb(241, 101, 45);
        }

    .dropdown {
        width: 114px;
        position: relative;
    }

    .dropdown-menu {
        padding: 7px 5px;
        display: none;
        position: absolute;
        width: 80px;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        background-color: #ffffff;
        border: 1px rgb(240, 240, 240) solid;
        top: 50px;
        left: 10px;
    }

    .dropdown:hover .dropdown-menu {
        display: block;
    }
</style>
