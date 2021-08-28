<template>
    <div>
        <div class="row">
            <div class="input-field col s4">
                <input id="date"
                    type="text" 
                    class="datepicker" 
                    v-date="{ name: 'dt', value: dt, format: 'd mmmm yyyy' }" 
                    autocomplete="off"/>
                <label for="date">Дата</label>
            </div>
            <div class="input-field col s2">
                <a class="btn-floating waves-effect waves-light btn-small pulse"
                    v-on:click.stop="upDt(dt)">
                    <i class="material-icons">
                        update
                    </i>
                </a>
            </div>
            <div class="col s6">
                <pre>
                    {{dt}}
                </pre>
            </div>
        </div>
        <div class="row">
            <div class="input-field col s6">
                <input id="date1"
                    type="text" 
                    class="datepicker" 
                    v-date="{ name: 'dt1', value: dt1, format: 'd mmmm yyyy' }" 
                    autocomplete="off"
                    />
                <label for="date1">Дата</label>
            </div>
            <div class="col s6">
                <pre>
                    {{dt1}}
                </pre>
            </div>
        </div>
    </div>
</template>

<script>
    import { ref } from 'vue'

    export default {
        setup(){
            const dt = ref(new Date());
            const dt1 = ref(new Date());
            const test = ref("");

            const upDt = ()=>{
                dt.value = new Date();
                dt.value.setHours(240);
            }

            return {
                dt,
                dt1,
                upDt,
                test
            }
        }
    }
</script>

<style scoped>

</style>