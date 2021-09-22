﻿using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZombieWars.Models;
using ZombieWars.BusinessLayer;

namespace ZombieWars.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly IMoneyBL _moneyBL;
    private readonly IFightingBL _fightingBL;

    public HomeController(ILogger<HomeController> logger, IMoneyBL money, IFightingBL fightingBL)
    {
      _logger = logger;
      _moneyBL = money;
      _fightingBL = fightingBL;
    }

    public IActionResult Index()
    {
      var player = new UserModel();
      player.Name = "Tony";
      player.Money = 100;
      player.Hp = 110;
      
      var model = new HomeViewModel();
      model.User = player;

      return View(model);
    }

    public IActionResult MakeMoney(int money)
    {
      return new JsonResult(money);
    }

    public IActionResult DoDamage(int baseDamage, UserModel player, MonsterModel monster)
    {
      var damageDone = _fightingBL.CalculateDamage(baseDamage);
      return new JsonResult(damageDone);
    }

    public IActionResult TestMoney()
    {
      var number = _moneyBL.RandomMoney();
      var result = _moneyBL.IsPrime(number);
      Console.WriteLine(number);
      Console.WriteLine(result);

      return new JsonResult(result);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
