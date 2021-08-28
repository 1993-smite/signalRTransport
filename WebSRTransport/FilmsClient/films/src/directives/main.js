export default {
    Directives
}

import M from 'materialize-css'

function writeDt(el, binding){
    var instance = M.Datepicker.getInstance(el);

    let dt = binding.instance[binding.value.name];

    if (dt?.toISOString() === instance.date?.toISOString())
        return;

    instance.setDate(dt);
    instance.gotoDate(dt);

    el.value = instance.toString();

    return instance;
}


function Directives(){
    this.directive('date', {
        created(){
            console.log('created', arguments);
        },
        mounted(el, binding, vnode) {
            let nw = new Date();
            let min = binding.value.min || new Date(new Date().setFullYear(nw.getFullYear() - 10));
            let max = binding.value.max || new Date(new Date().setFullYear(nw.getFullYear() + 10));

            M.Datepicker.init(el, {
                defaultDate: binding.value.value,
                minDate: min,
                maxDate: max,
                format: binding.value.format || 'dd mmmm',
                i18n: {
                    months: ["Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"],
                    monthsShort: ["Янв", "Фев", "Мар", "Апр", "Май", "Июнь", "Июль", "Авг", "Сен", "Окт", "Нбр", "Дек"],
                    weekdays: ["Воскресенье","Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота"],
                    weekdaysShort: ["Вс","Пон", "Вт", "Ср", "Чет", "Пят", "Суб"],
                    weekdaysAbbrev: ["Вс","Пн", "Вт", "Ср", "Чт", "Пт", "Сб"]
                },
                onSelect: function(date){
                    //context.task.date = new Date(date.setHours(5));
                    //this.task
                    console.log('dt ---', date);

                    let dt = binding.instance[binding.value.name];

                    if (dt?.toISOString() !== date?.toISOString())
                        binding.instance[binding.value.name] = date;
                }
            });
            writeDt(el, binding, vnode);
            console.log(el, binding, vnode);
        },
        updated(el, binding, vnode){
            writeDt(el, binding, vnode);
        }
    })
}

