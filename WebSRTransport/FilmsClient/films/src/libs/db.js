export default {
    saveGeolocation
}

const axios = require('axios')
const urlAddress = 'http://localhost:9999/api/Address';

async function saveGeolocation(geoLocation){

    let rer = 323;
    await axios.post(urlAddress, geoLocation).then((response)=>{
        console.log(response, rer);
    });

}


