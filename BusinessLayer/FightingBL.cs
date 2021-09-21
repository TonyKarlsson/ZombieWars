using System;
using ZombieWars.Models;

namespace ZombieWars.BusinessLayer
{
  public interface IFightingBL
  {
    int CalculateDamage(int baseDamage);

  }
  public class FightingBL : IFightingBL
  {
    public int CalculateDamage(int baseDamage)
    {
      int damageDone = baseDamage * new Random().Next(10);
      return damageDone;
    }

    public void DamageToPlayer(UserModel player, int baseDamage)
    {
      var damageDone = CalculateDamage(baseDamage);
      player.Hp -= damageDone;

    }

  }
}