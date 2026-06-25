<script setup>
    import { ref, computed, defineEmits } from 'vue';
    const props = defineProps({
        pageSize: { type: Number, required: true },
        total: { type: Number, required: true }
    });
    const currentPage = ref(1);
    const totalPages = computed(() => {
        return Math.ceil(props.total / props.pageSize);
    });
    const maxPageNumbers = 4;
    const middlePage = Math.floor(maxPageNumbers / 2);
    const startPage = computed(() => {
        let start = currentPage.value - middlePage;
        if (start <= 0) {
            start = 1;
            return start;
        }
        return start;
    });
    const endPage = computed(() => {
        let end = currentPage.value + middlePage;
        if (end > totalPages.value) {
            end = totalPages.value;
            return end;
        }
        return end;
    });
    const pageNumbers = computed(() => {
        const start = startPage.value;
        const end = endPage.value;
        return Array(end - start + 1).fill().map((_, index) => start + index);
    });
    const setCurrentPage = (page) => {
        if (page >= 1 && page <= totalPages.value) {
            currentPage.value = page;
            emit('current-change', page);
        }
    };
    const emit = defineEmits(['current-change']);
</script>

<template>
    <div class="pagination">
        <button v-bind:disabled="currentPage === 1" @click="setCurrentPage(currentPage - 1)">
            <img src="@/assets/pagenation/向左.png" alt="" class="icon">
        </button>

        <template v-for=" pageNumber in pageNumbers">
            <button :class="{ active: pageNumber === currentPage }" @click="setCurrentPage(pageNumber)">
                {{ pageNumber }}
            </button>
        </template>

        <button v-bind:disabled="currentPage === totalPages" @click="setCurrentPage(currentPage + 1)">
            <img src="@/assets/pagenation/向右.png" alt="" class="icon">
        </button>
    </div>
</template>

<style scoped>
    .icon {
        width: 15px;
        height: 15px;
    }
    .pagination {
        display: flex;
        justify-content: center;
        margin-top: 0;
    }
        .pagination button {
            display: flex;
            justify-content: center;
            align-items: center;
            background-color: #fff;
            width: 32px;
            height: 32px;
            margin: 0 5px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
            .pagination button:disabled {
                cursor: not-allowed;
            }
                .pagination button:disabled > img {
                    opacity: 0.5;
                }
            .pagination button.active {
                color: rgb(241, 101, 45);
            }
</style>
