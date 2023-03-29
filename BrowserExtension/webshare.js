"use strict";

addEventListener("DOMContentLoaded", (event) => {
    var connection = new signalR.HubConnectionBuilder().withUrl("/sharehub").build();

    connection.on("ReceiveMessage", function (url) {
        console.log("Receive " + url);
        window.open(url, '_blank');
    });

    connection.start()
        .then(() => getConnectionId())
        .catch(function (err) {
            return console.error(err.toString());
        });

    var getConnectionId = () => {
        console.log("get connection ID");
        connection.invoke('GetConnectionId')
            .then((data) => {
                console.log(data);
                new QRCode(document.getElementById("qr"), data);
            });
    }
});



