export default {
    getCoordinateByAddress
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