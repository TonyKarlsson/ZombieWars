const inventory = {
  knife: 1, 
  gun: 0, 
  money: 100
};

  for (const [object, amount] of Object.entries(inventory)) {
    let newInventoryRow = `<tr> <td>${object}</td> <td>${amount}</td> </tr>`;
    let inventoryRow = document.querySelector(".inventoryRow");
    inventoryRow.insertAdjacentHTML("afterbegin",newInventoryRow);
    console.log(object);
  }
