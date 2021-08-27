<template>
    <div>
        <div class="row">
            <div class="input-field col s6">
                <input id="date"
                    type="text" 
                    class="datepicker" 
                    v-date="{ name: 'dt', value: dt, format: 'dd mmmm yyyy' }" />
                <label for="date">Дата</label>
            </div>
            <div class="col s6">
                <pre>
                    {{dt}}
                </pre>
            </div>
        </div>
        <div class="row">
            <div class="input-field col s6">
                <input id="date"
                    type="text" 
                    class="datepicker" 
                    v-date="{ name: 'dt1', value: dt1, format: 'dd mmmm yyyy' }" />
                <label for="date">Дата</label>
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

            return {
                dt,
                dt1,
                test
            }
        }
    }
</script>

<style scoped>

</style>