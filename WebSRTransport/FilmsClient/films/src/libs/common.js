let Common = {
    createFromProto: function(proto, obj){
        let object = {...proto};
        return Object.assign(object, obj);
    },

    trimChars: function(str, c) {
        var re = new RegExp("^[" + c + "]+|[" + c + "]+$", "g");
        return str.replace(re,"");
    },
    
    objToStr: function(obj){
        let str = '';
        for (const key in obj) {
            if (obj[key].toString().length > 0){
                str = `${str}&${key}=${obj[key]}`;
            }
        }
        return this.trimChars(str,'&');
    }
}

export default Object.freeze(Common);