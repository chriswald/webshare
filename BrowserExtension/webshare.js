"use strict";

addEventListener("DOMContentLoaded", (event) => {
    let connection = new signalR.HubConnectionBuilder().withUrl("/sharehub").build();

    connection.on("ReceiveMessage", function (url) {
        console.log("Receive " + url);

        let a = document.createElement("a");
        a.href = url;
        a.target = "_blank";
        a.innerText = url;

        document.getElementById("link").innerHTML = "";
        document.getElementById("link").appendChild(a);

        let newTab = window.open(url, "_blank");

        if (newTab === null) {
            window.location.href = url;
        }
    });

    connection.start()
        .then(() => getConnectionId())
        .catch(function (err) {
            return console.error(err.toString());
        });

    let getConnectionId = () => {
        console.log("get connection ID");
        connection.invoke('GetConnectionId')
            .then((data) => {
                console.log(data);
                new QRCode(document.getElementById("qr"), data);
            });
    }
});



