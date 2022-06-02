"use strict";

var connection = new signalR.HubConnectionBuilder()
  .withUrl("/chat").build();

document.getElementById("registerButton").disabled = true;
document.getElementById("sendButton").disabled = true;

document.getElementById("myName").addEventListener("input",
  function () {
    document.getElementById("from").value =
      document.getElementById("myName").value;
  }
);

connection.start().then(function () {
  document.getElementById("registerButton").disabled = false;
  document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
  return console.error(err.toString());
});

connection.on("ReceiveMessage", function (received) {
  var li = document.createElement("li");
  document.getElementById("messages").appendChild(li);
  // note the use of backtick ` to enable a formatted string
  li.textContent =
    `To ${received.to}, From ${received.from}: ${received.body}`;
});

document.getElementById("registerButton").addEventListener("click",
  function (event) {
    var registermodel = {
      name: document.getElementById("myName").value,
      groups: document.getElementById("myGroups").value
    };
    connection.invoke("Register", registermodel).catch(function (err) {
      return console.error(err.toString());
    });
    event.preventDefault();
  });

document.getElementById("sendButton").addEventListener("click",
  function (event) {
    var messagemodel = {
      from: document.getElementById("from").value,
      to: document.getElementById("to").value,
      body: document.getElementById("body").value
    };
    connection.invoke("SendMessage", messagemodel).catch(function (err) {
      return console.error(err.toString());
    });
    event.preventDefault();
  });
