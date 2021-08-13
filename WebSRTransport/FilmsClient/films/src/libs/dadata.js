export default {
    fetchData
}

async function fetchData (){
    var context = this;
    var url = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/address";
    var token = "9d035861f269ba41c82ce284ab4afd3b3979ba93";
    var options = {
        method: "POST",
        mode: "cors",
        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json",
            "Authorization": "Token " + token
        },
        body: JSON.stringify({
            query: this.address, 
            locations: [
                {
                    "region": "москва"
                }
            ],
            count: 5})
    }
    fetch(url, options)
        .then(response => response.json())
        .then(result => {
            let vals = result.suggestions.map(x=>x.value);
            context.addresses = {};

            for(let itm of vals){
                context.addresses[`${itm}`] = itm;
            }

            context.elemAddress.updateData(context.addresses);

        })
        .catch(error => console.log("error", error));
}