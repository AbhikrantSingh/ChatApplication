//create connection

var connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hubs/userCount").build();

//connect to methodd that hub
connectionUserCount.on("updateTotalViews", (value) => {

    var newCountSpan = document.getElementById("totalViewsCounter");
    newCountSpan.innerText = value.toString();
});


connectionUserCount.on("updateTotalUser", (value) => {

    var newCountSpan = document.getElementById("totalUsersCounter");
    newCountSpan.innerText = value.toString();
});

function newWindowLoadedOnClient() {
    connectionUserCount.send("NewWindowLoaded");
}
//start the connection

function fulfilled() {
    console.log("Success")
    newWindowLoadedOnClient();
}

function rejected() {
    console.log("FAILED");
}


connectionUserCount.start().then(fulfilled, rejected)