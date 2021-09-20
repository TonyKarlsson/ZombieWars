    const setMoney = (money) => {
      $.ajax({
          url: "home/makemoney",
          data: { money: money },
          success: (res) => {
              console.log(res);
          }
      })
    }

    const showMoney = (event) => {
      let randomMoney = Math.floor(Math.random() * 100);
      if (isPrime(randomMoney)) {
        let loseMoney = -randomMoney * 2;
        addMoney(loseMoney);
        setMoney(loseMoney);
        event.preventDefault();
      } else {
        addMoney(randomMoney);
        setMoney(randomMoney);
      }

      event.preventDefault();
    }

    const isPrime = num => {
      for(let i = 2; i < num; i++)
        if(num % i === 0) return false;
      return num > 1;
    }

    const addMoney = (amountToAdd) => {
      let currentBalance = document.querySelector(".currentBalance").innerHTML;
      let newBalance = amountToAdd + parseInt(currentBalance);
      document.querySelector(".currentBalance").innerHTML = newBalance;
      if (amountToAdd > 0) {
        logEvent(`Added money`, `${amountToAdd} moneyz`);
      } else {
        logEvent(`Lost money`, `${amountToAdd} moneyz`);
      }
    }

    const calculateDamage = (baseDamage) => {
      let damageDone = baseDamage * Math.ceil(Math.random() * 10);
      return damageDone;
    }

    const damageToPlayer = (baseDamage) => {
      let damageDone = calculateDamage(baseDamage);
      let currentPlayerHp = document.querySelector(".currentPlayerHp");
      let newPlayerHp = currentPlayerHp.innerHTML - damageDone;
      let latestDamage = document.querySelector(".damageToPlayer");

      if (newPlayerHp < 1) {
        document.querySelector(".playerDead").innerHTML = "You are dead!";
        logEvent(`You were killed!`, `taking ${damageDone} damage!`);
      } else {
        latestDamage.innerHTML = `(-${damageDone})`;
        currentPlayerHp.innerHTML = newPlayerHp;
        logEvent(`Zombie retaliated!`, `You take ${damageDone} damage!`);
      }
      return damageDone;
    }

    const damageToMonster = (baseDamage) => {
      console.log(inventory.knife);
      let fightMove;
      if (baseDamage == 1) {
        fightMove = "punched ";
      } else if (baseDamage == 5) {
        fightMove = "stabbed ";
      } else {
        fightMove = "shot ";
      }

      let damageDone = calculateDamage(baseDamage);
      let currentMonsterHp = document.querySelector(".currentMonsterHp").innerHTML;
      let newMonsterHp = currentMonsterHp - damageDone;
      let latestDamageToMonster = document.querySelector(".damage-to-monster");

      if (newMonsterHp < 1) {
        document.querySelector(".monsterDead").innerHTML = "You killed it!"

        logEvent(`You killed it`, `doing ${damageDone} damage!`);
      } else {
        latestDamageToMonster.innerHTML = `(-${damageDone})`;
        document.querySelector(".currentMonsterHp").innerHTML = newMonsterHp;
        logEvent(`You ${fightMove} it`, `doing ${damageDone} damage!`);
        retaliate("Zombie");
      }
      
      return damageDone;
    }

    const logEvent = (event = "event", message = "message") => {
      let newLogRow = `<tr> <td>${event}</td> <td>${message}</td> </tr>`;
      let eventRow = document.querySelector(".eventRow");
      eventRow.insertAdjacentHTML("afterbegin",newLogRow);
    }

    const retaliate = (type = "Zombie") => {
      if (type = "Zombie" && Math.ceil(Math.random() * 10) < 5) {
        damageToPlayer(6);
      }
    }

    let moneyButton = document.querySelector(".addMoney");
    let newMonster = document.querySelector(".new-monster");
    moneyButton.addEventListener("submit", showMoney);


