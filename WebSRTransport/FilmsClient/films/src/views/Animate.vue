<template>
    <div>
        <div class="row">
            <div class="col s6">
                <transition name="bounce">
                    <p v-if="show">
                        {{test}}
                    </p>
                </transition>
            </div>
            <div class="col s6">
                <span id="sp-btn-toggle"
                    v-on:click="Log('Всплытие')">
                    <button @click="Log('Цель'); show = !show">Toggle show</button>
                </span>
            </div>
        </div>
    </div>
</template>

<script>
    import { ref } from 'vue'
    import M from 'materialize-css'

    export default {
        setup(){
            const test = ref("Test");
            const show = ref(true);

            let Log = (str)=>{
                console.log(str);
            } 

            return {
                test,
                show,
                Log
            }
        },
        mounted(){
            M.updateTextFields();

            document.getElementById("sp-btn-toggle").addEventListener("click", function(){
                console.log("Погружение");
            }, true)
        }
    }
</script>

<style scoped>
    .bounce-enter-active {
        animation: bounce-in 0.5s;
    }
    .bounce-leave-active {
        animation: bounce-in 0.5s reverse;
    }
    @keyframes bounce-in {
        0% {
            transform: scale(0);
        }
        50% {
            transform: scale(1.25);
        }
        100% {
            transform: scale(1);
        }
    }
</style>