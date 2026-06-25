<script setup>
    defineOptions({
        name: 'message'
    })
    const props = defineProps({
        message: {
            type: String,
            required: true
        },
        type: {
            type: String,
            default: 'info'
        }
    });
    const emit = defineEmits(['dismiss']);
    const dismiss = () => {
        emit('dismiss');
    };
</script>

<template>
    <div v-bind:class="type">
        <div class="row">
            <div class="col-11">{{ message }}</div>
            <div class="col-1">
                <button class="btn btn-danger" @click="dismiss">X</button>
            </div>
        </div>
    </div>
</template>

<style scoped>
    .message {
        display: flex;
        justify-content: space-between;
        position: fixed;
        width: 500px;
        height: 230px;
        left: calc(50% - 250px);
        top: 30px;
        z-index: 9999;
        padding: 12px;
        border-radius: 4px;
        margin-bottom: 8px;
    }

    .info {
        background-color: #e6f7ff;
        color: #1890ff;
    }

    .success {
        background-color: #f6ffed;
       background-color:gray;
        color: #52c41a;
    }

    .warning {
        background-color: #fffbe6;
        color: #faad14;
    }

    .error {
        background-color: #fff2f0;
        color: #f5222d;
    }

/*    button {
        border: none;
        background: transparent;
        cursor: pointer;
    }*/
</style>
