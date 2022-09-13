"use strict";

var connection = new signalR.HubConnectionBuilder()
  .withUrl("/stockprice").build();

document.getElementById("updateButton").disabled = true;

connection.start().then(function () {
  document.getElementById("updateButton").disabled = false;
}).catch(function (err) {
  return console.error(err.toString());
});

connection.on("ReceiveStockPriceUpdate", function (received) {
  var li = document.createElement("li");
  document.getElementById("messages").appendChild(li);
  // note the use of backtick ` to enable a formatted string
  li.textContent =
    `${received.stock} is now ${received.price}`;
});

document.getElementById("updateButton").addEventListener("click",
  function (event) {
    var updatemodel = {
      stock: document.getElementById("stockTextBox").value,
      price: document.getElementById("priceTextBox").value
    };
    connection.invoke("BroadcastUpdate", updatemodel)
      .catch(function (err) {
      return console.error(err.toString());
    });
    event.preventDefault();
  });
