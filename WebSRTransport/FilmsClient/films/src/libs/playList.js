let index = 1;
let playList = {
    base: "D:\\Data",
    list: [
        {
            name: `Rec 000${index++}.mp4`
        },
        {
            name: `Rec 000${index++}.mp4`
        },
        {
            name: `Rec 000${index++}.mp4`
        },
        {
            name: `Rec 000${index++}.mp4`
        },
        {
            name: `Rec 000${index++}.mp4`
        },
    ],
    getPath: function(item){
        return `${this.base}/${item.name}`;
    }
}

export default playList;
