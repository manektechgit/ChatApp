

////var connection = new signalR.HubConnectionBuilder().withUrl("/aspdontnetcoredemo/chathub").build();
//var wsconn = new signalR.HubConnectionBuilder().withUrl("/aspdontnetcoredemo/callhub", signalR.HttpTransportType.WebSockets).configureLogging(signalR.LogLevel.None).build();
var connection = new signalR.HubConnectionBuilder().withUrl("https://project-demo-server.net/aspdontnetcoredemo/chathub").build();
//var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();
$(document).ready(function () {
    //getAll();
    //connection.on("ActiveInactiveUser", function () {
    //    getAll();
    //});
    //connection.on("SendMessageToUser", function () {
    //    getAllMessage();
    //});
    connection.start();

    var userID=$('#hdnUserId').val();
    connection.on("UserConnected", function (connectionId, userID) {
        console.log('my id is :' + connection.connectionId);
        console.log($('#hdnUserId').val());
    });
    
  
    //connectioncall.on("UserConnected", function (connectionId, userID) {
    //    console.log('my id is :' + connectioncall.connectionId);
    //    console.log($('#hdnUserId').val());
    //});
    //initializeSignalR();
   // wsconn.start();    
});





