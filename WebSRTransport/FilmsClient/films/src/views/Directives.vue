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
        <div class="row">
            <div class="input-field col s6">
                <div class="col s12">
                    <ul class="tabs">
                        <li class="tab col s6">
                            <a class="active" 
                                href="#editor">
                                Редактор
                            </a>
                        </li>
                        <li class="tab col s6">
                            <a href="#resultor">
                                HTML
                            </a>
                        </li>
                    </ul>
                </div>
                <div id="editor" 
                    class="col s12">
                    <i class="small pointer material-icons button"
                        format="b"
                        v-bind:class="{ disabled: !getSelection }"
                        v-on:click="formatingText($event)"
                        >format_bold</i>
                    <i class="small pointer material-icons button"
                        format="i"
                        v-bind:class="{ disabled: !getSelection }"
                        v-on:click="formatingText($event)"
                        >format_italic</i>
                    <i class="small pointer material-icons button"
                        format="u"
                        v-bind:class="{ disabled: !getSelection }"
                        v-on:click="formatingText($event)"
                        >format_color_text</i>
                    <i class="small pointer material-icons button red-text"
                        format="red"
                        v-bind:class="{ disabled: !getSelection }"
                        v-on:click="formatingText($event)"
                        >format_paint</i>
                    <div ref="editable"
                        id="editable"
                        contenteditable
                        v-on:input="editContent($event)"
                        v-on:keyup.enter="editContent($event, true)"
                        style="border: 1px solid black">
                    </div>
                </div>
                <div id="resultor" 
                    class="col s12"
                    v-html="contentBlock">
                </div>
            </div>
            <div class="col s6">
                <div
                    v-html="contentBlock">

                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import { ref, reactive, computed } from 'vue'
    import M from 'materialize-css'

    String.prototype.replaceAll = function(search, replace){
        return this.split(search).join(replace);
    }


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

            // editable content 
            const editable = ref();
            let content = reactive([]);
            let contentLine = computed(()=>{
                return content.value?.join('\n') || ""; 
            });
            let contentBlock = computed(()=>{
                return content.value?.join('<br>') || ""; 
            });
            const editContent = (event)=>{
                content.value = event.target.innerHTML
                    .replaceAll('&lt;', '<')
                    .replaceAll('&gt;', '>')
                    .replaceAll('</div>', '').split('<div>');
            }
            let selection = reactive({ 
                text: window.getSelection().toString(),
                start: 0,
                end: 0
            })
            let getSelection = computed(() => selection.text.trim().length > 0 );
            const changeSelection = (event, secondCall)=>{
                //let el = event.target;
                if (!secondCall){
                    setTimeout(()=>changeSelection(event, true), 300);
                    return;
                }

                let selVal = document.getSelection().toString();

                let sel = window.getSelection();
                let range = sel.getRangeAt(0);
                let start = range.startOffset;
                let end = range.endOffset;

                console.log(sel, range, start, end);

                if (contentLine.value.includes(selVal)){
                    selection.text = document.getSelection().toString();
                    selection.start = start;
                    selection.end = end;
                    selection.obj = sel;
                    selection.range = range;
                }
                else {
                    selection.text = "";
                    selection.start = 0;
                    selection.end = 0;
                    
                }
            }
            const formatingText = (event)=>{
                let formating = '';
                let text = selection.text;
                
                switch(event.target.getAttribute("format")){
                    case 'b':
                        formating = `<b>${text.replaceAll('\n','</b>\n<b>')}</b>`;
                        break;
                    case 'i':
                        formating = `<i>${text.replaceAll('\n','</i>\n<i>')}</i>`;
                        break;
                    case 'u':
                        formating = `<u>${text.replaceAll('\n','</u>\n<u>')}</u>`;
                        break;
                    case 'red':
                        formating = `<p class="red-text">${text.replaceAll('\n','</p><p class="red-text">')}</p>`;
                        break;
                    default:
                        console.error("not formating this action");
                }

                console.log(editable.value, formating)

                let newContentLine = contentLine.value.substring(0, selection.start) 
                        + formating 
                        + contentLine.value.substring(selection.end);
                content.value = newContentLine.split('\n');
                // content.value = content.value.substring(0, selection.start) 
                //     + formating 
                //     + content.value.substring(selection.end);
                // document.getElementById(editable.value.id).textContent = content.value;
            }

            return {
                dt,
                dt1,
                upDt,
                test,
                data,
                
                getData,
                
                content,
                contentLine,
                contentBlock,
                editContent,
                selection,
                getSelection,
                changeSelection,
                formatingText,
                editable
            }
        },
        mounted(){
            M.updateTextFields();
            
            let tabs = document.querySelector(".tabs");
            M.Tabs.init(tabs, {

            });

            let context = this;
            window.addEventListener('mouseup', e => {
                context.changeSelection(e, false);
            });

            //this.editable = document.querySelector("#editable");
        }
    }
</script>

<style scoped>
    i.button:hover:not(.disabled){
        background-color: burlywood;
    }
    i.button.disabled{
        opacity: 0.4;
    }
</style>