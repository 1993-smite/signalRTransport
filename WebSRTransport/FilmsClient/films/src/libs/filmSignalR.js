const signalR = require("@microsoft/signalr");
import M from 'materialize-css'

let connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:1040/common?group=test")
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

window.addEventListener("unload", function() {
    console.log("bye");
    connection.stop();
});

export default {
    hub: connection
}