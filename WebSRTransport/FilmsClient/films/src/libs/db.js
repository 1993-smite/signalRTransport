export default {
    saveGeolocation,
    clusterization
}

const axios = require('axios')
const urlAddress = 'http://localhost:9999/api/Address';
const urlClusterize = 'http://localhost:9999/api/Clusterize/AccordKMeans';

async function saveGeolocation(geoLocation){
    let rer = 323;
    await axios.post(urlAddress, geoLocation).then((response)=>{
        console.log(response, rer);
    });
}

async function clusterization(geoLocations){
    let response = await axios.post(urlClusterize, 
        {
            "Places": geoLocations,
            "Count": 3
        });
    let data = response.data;
    console.log(data);
    for (let index = 0;index < data.length; index++) {
        let cluster = data[index];
        for (let i=0; i < cluster.points.length; i++) {
            let item = cluster.points[i];
            let exist = geoLocations
                .find(x=> Math.abs(x.lat - item.lat) < 1e-8 
                        && Math.abs(x.lon - item.lon) < 1e-8); 
            if (exist){
                exist.cluster = index;
            }
        }
    }
    return geoLocations;
}


