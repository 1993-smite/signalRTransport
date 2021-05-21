const signalR = require("@microsoft/signalr");
import M from 'materialize-css'

let connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:1040/film")
    .build();

connection.on('Receive', data => {
    console.log("Receive",data);
});
connection.on("send", data => {
    console.log("send",data);
    M.toast({html: data, classes: 'red'})
});
connection.on("notify", data => {
    console.log("notify",data);
    M.toast({html: data, classes: 'yellow'})
});

connection.start()
    .then(() => connection.invoke("send", "Hello"));

export default {
    hub: connection
}