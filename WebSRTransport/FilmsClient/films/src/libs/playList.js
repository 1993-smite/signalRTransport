let index = 1;

let playList = {
    base: 'http://localhost:9000/video/',
    list: [
        {
            name: `Rec${index++}.mp4`,
        },
        {
            name: `Rec${index++}.mp4`,
        },
        {
            name: `Rec${index++}.mp4`,
        },
        {
            name: `Rec${index++}.mp4`
        },
        {
            name: `Rec${index++}.mp4`
        },
    ],
    getPath: function(item){
        return item.path || `${this.base}${item.name}`;
    }
}

export default playList;
