using System;

namespace ZombieWars.BusinessLayer
{
  public interface IMoneyBL
  {
    bool IsPrime(int num);
    void ShowMoney();
  }

  public class MoneyBL : IMoneyBL
  {
    public MoneyBL()
    {
    }

    public bool IsPrime(int num)
    {
      for (int i = 2; i < num; i++)
      {
        if (num % i == 0)
        {
          return false;
        }
      }

      return num > 1;
    }

    public void ShowMoney()
    {
      int randomMoney = new Random().Next(100);

      if (IsPrime(randomMoney))
      {
        int loseMoney = -randomMoney * 2;
        AddMoney(loseMoney);
        SetMoney(loseMoney);
      }
      else
      {
        AddMoney(randomMoney);
        SetMoney(randomMoney);
      }
    }

    public decimal AddMoney(decimal money)
    {
      return money * 12;
    }

    public decimal SetMoney(decimal money)
    {
      return money * 12;
    }
  }
}