<template>
    <div class="header">
        <div class="title">
            <slot name="title">
            </slot>
        </div>
        <div class="icons pointer"
            v-on:click="toggle()">
            <i 
            class="small material-icons s1"
            v-show="show">arrow_drop_up</i>
            <i 
            class="small material-icons s1"
            v-show="!show">arrow_drop_down</i>
        </div>
    </div>
    <div v-show="show">
        <slot>
        </slot>
    </div>
</template>

<script>
    import { ref } from 'vue'

    export default {
        setup(showDiv = false){
            const show = ref(showDiv)
            const toggle = () => {
                show.value = !show.value;
            }

            return {
                show,
                toggle
            }
        }
    }
</script>

<style scoped>
    .header{
        display: inline-flex;
    }
    .material-icons{
        margin-top: 18px;
    }
    .btn{
        display: in;
    }
</style>