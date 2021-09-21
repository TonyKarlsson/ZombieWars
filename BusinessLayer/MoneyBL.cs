using System;

namespace ZombieWars.BusinessLayer
{
  public interface IMoneyBL
  {
    bool IsPrime(int num);
    void ShowMoney();
    int RandomMoney();
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

    public int RandomMoney()
    {
      int randomNumber = new Random().Next(100);
      return randomNumber;
    }

    public void ShowMoney()
    {
      if (IsPrime(RandomMoney()))
      {
        int loseMoney = RandomMoney() * -2;
        AddMoney(loseMoney);
        SetMoney(loseMoney);
      }
      else
      {
        AddMoney(RandomMoney());
        SetMoney(RandomMoney());
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