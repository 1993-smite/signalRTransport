const url = 'https://api.github.com/search/users?q=';

let EMPTY, fromEvent;
let map, debounceTime, distinctUntilChanged, switchMap, mergeMap, tap, catchError, filter;
let ajax;

let search;
let result;


function init() {
    EMPTY = rxjs.EMPTY;
    fromEvent = rxjs.fromEvent;
    // -------------------------
    map = rxjs.operators.map;
    debounceTime = rxjs.operators.debounceTime;
    distinctUntilChanged = rxjs.operators.distinctUntilChanged;
    switchMap = rxjs.operators.switchMap;
    mergeMap = rxjs.operators.mergeMap;
    tap = rxjs.operators.tap;
    catchError = rxjs.operators.catchError;
    filter = rxjs.operators.filter;
    // -------------------------
    ajax = rxjs.ajax.ajax;
    // -------------------------
    search = document.getElementById('searchTxt')
    result = document.getElementById('result')
}

function ready() {
    const stream$ = fromEvent(search, 'input')
        .pipe(
            map(e => e.target.value),
            debounceTime(1000),
            distinctUntilChanged(),
            tap(() => result.innerHTML = ''),
            filter(v => v.trim()),
            switchMap(v => ajax.getJSON(url + v).pipe(
                catchError(err => EMPTY)
            )),
            map(response => response.items)
        )


    stream$.subscribe(json => {
        result.innerHTML = JSON.stringify(json,undefined, 2);
    })
}


document.addEventListener('DOMContentLoaded', function () {

    init();
    ready();

}, false);