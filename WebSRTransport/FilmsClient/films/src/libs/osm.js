export default {
    getCoordinateByAddress,
    getRouteByCoordinates
}

/**
 * check address and return coordinate by address
 * @param {*} address 
 * @returns coordinate
 */
async function getCoordinateByAddress(address){
    let response = await 
            fetch(`http://search.maps.sputnik.ru/search/addr?tlat=56.1&tlon=36.8&blat=55.4&blon=38.6&q=${address}`);
        let result = await response.json();
    return result.result;
}

/**
 * get route by coordinates
 * @param {*} coord 
 */
async function getRouteByCoordinates(coord){
    let url = 'http://router.project-osrm.org/trip/v1/driving/'

    if (!(coord.length > 1 && Array.isArray(coord))){
        throw new Error("Coord param has been array!");
    }

    let params = coord.reduce((prev, cur) => prev.length > 1 ? `${prev};${cur[0]},${cur[1]}` : `${cur[0]},${cur[1]}`, '');

    let response = await fetch(`${url}${params}?steps=true`);
    let result = await response.json();
    
    //console.log(result);

    return result.trips[0].legs;
}