
//Create Connection

var connectionDeathlyHallows = new signalR.HubConnectionBuilder()
    .withUrl("/hubs/deathlyhallows", signalR.HttpTransportType.WebSockets).build();



var Cloakspan = document.getElementById("cloakCounter");
var Stonespan = document.getElementById("stoneCounter");
var Wandspan = document.getElementById("wandCounter");
// connect to the method that hub invokes aka receice notificatins from hub
connectionDeathlyHallows.on("updateDeathlyHollowCount", (cloak,stone,wand) => {
    
    Cloakspan.innerText = cloak.toString();
    Stonespan.innerText = stone.toString();
    Wandspan.innerText = wand.toString();
});



//connectionUserCount.on("updateTotalUser", (value) => {

//    var newCountSpan = document.getElementById("totalUsersCounter");
//    newCountSpan.innerText = value.toString();
//});

//function newWindowLoadedOnClient() {
//    connectionUserCount.invoke("NewWindowLoaded").then((value) => console.log(value));
//}
//start the connection

function fulfilled() {
    console.log("Success")
    connectionDeathlyHallows.invoke("GetRaceStatus").then((raceCounter) => {
        Cloakspan.innerText = raceCounter.cloak.toString();
        Wandspan.innerText = raceCounter.wand.toString();
        Stonespan.innerText = raceCounter.stone.toString();
    });
    newWindowLoadedOnClient();
}

function rejected() {
    console.log("FAILED");
}


connectionDeathlyHallows.start().then(fulfilled, rejected)
                                