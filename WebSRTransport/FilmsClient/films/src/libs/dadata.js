export default {
    fetchData,
    getAddress
}

/**
 * 
 * @param {*} lat 
 * @param {*} lon 
 */
async function getAddress(lat, lon){
    var url = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/geolocate/address";
    var token = "9d035861f269ba41c82ce284ab4afd3b3979ba93";
    var query = { lat: lat, lon: lon };

    var options = {
        method: "POST",
        mode: "cors",
        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json",
            "Authorization": "Token " + token
        },
        body: JSON.stringify(query)
    }

    let response = await fetch(url, options)
    let result = await response.json();

    return result;
}

/**
 * 
 * @param {*} address 
 * @returns 
 */
async function fetchData (address){
    let url = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/address";
    let token = "9d035861f269ba41c82ce284ab4afd3b3979ba93";
    let secret = "705eccbd748bfd6ff04613e04e833a8c6c676262"
    let vals;
    var options = {
        method: "POST",
        mode: "cors",
        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json",
            "Authorization": "Token " + token,
            "X-Secret": secret
        },
        body: JSON.stringify({
            query: address, 
            locations: [
                {
                    "region": "Москва",
                    "fias_level": 9
                }
            ],
            count: 10})
    }
    let response = await fetch(url, options)
    let result = await response.json();
    vals = result.suggestions.map(x=>x.value);
    return vals;
}