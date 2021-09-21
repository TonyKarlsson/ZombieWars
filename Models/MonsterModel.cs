using System;

namespace ZombieWars.Models
{
  public class MonsterModel
  {
    public string Type { get; set; }
    public decimal Hp { get; set; }
    public decimal Damage { get; set; }
  }

  public class ZombieModel : IMonsterModel
  {
    public ZombieModel(decimal hp, decimal damage)
    {
      Type = "Zombie";
      Hp = hp;
      Damage = damage;
    }
    public string Type { get; private set; }
    public decimal Hp { get; set; }
    public decimal Damage { get; set; }
  }

  public interface IMonsterModel
  {
    string Type { get; }
    decimal Hp { get; set; }
    decimal Damage { get; set; }
  }
}