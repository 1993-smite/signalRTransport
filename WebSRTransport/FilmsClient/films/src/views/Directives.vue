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
                <input id="club"
                    type="text"
                    v-autocomplete="{ name: 'test', value: test, data: data, minLength: 1, getData: getData }" 
                    autocomplete="off"
                    />
                <label for="club">Клуб</label>
            </div>
            <div class="col s6">
                <pre>
                    {{test}}
                </pre>
            </div>
        </div>
    </div>
</template>

<script>
    import { ref, reactive } from 'vue'
    import M from 'materialize-css'

    export default {
        setup(){
            const dt = ref(new Date());
            const dt1 = ref(new Date());
            const test = ref("");
            const data = reactive({
                "Реал Мадрид": null,
                "Милан": null,
                "Барселона": null,
                "Бавария": null,
                "Интер": null,
                "Ювентус": null,
                "Боруссия": null,
                "Манчестер Юнайтед": null,
                "Манчестер Сити": null,
                "Челси": null,
                "Арсенал": null,
                "Лацио": null,
                "Рома": null,
                "Атлетико Мадрид": null,
                "Севилья": null,
                "Валенсия": null,
                "Байер": null,
                "Бенфика": null,
                "Порту": null,
                "Наполи": null,
                "ПСЖ": null,
                "Лион": null,
                "Монако": null,
                "Тотенхем": null,
                "Ливерпуль": null,
            });

            const upDt = ()=>{
                dt.value = new Date();
                dt.value.setHours(240);
            }

            const getData = () => {
                return {
                    "Спартак Москва": null,
                    "ЦСКА Москва": null,
                    "Локомотив Москва": null,
                    "Зенит": null,
                    "Рубин": null,
                    "Динамо Москва": null,
                    "Краснодар": null,
                    "Сочи": null,
                    "Ростов": null,
                    "Ахмат": null,
                    "Нижний Новгород": null,
                    "Крылья Советов": null,
                    "Химки": null,
                    "Уфа": null,
                    "Арсенал Тула": null,
                    "Торпедо Москва": null,
                    "Оренбург": null,
                    "Факел": null,
                    "СКА-Хабаровск": null,
                    "Алания": null,
                    "КАМАЗ": null,
                    "Томь": null,
                    "Балтика": null,
                    "Ротор": null,
                    "Енисей": null,
                    "Кубань": null,
                    "Волгарь": null,
                    "Металлург": null,
                    "Текстильщик": null,
                }
            }

            return {
                dt,
                dt1,
                upDt,
                test,
                data,
                getData
            }
        },
        mounted(){
            M.updateTextFields();
        }
    }
</script>

<style scoped>

</style>