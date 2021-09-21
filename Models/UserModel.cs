using System;

namespace ZombieWars.Models
{
  public class UserModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Money { get; set; }
    public decimal Hp { get; set; }
  }
}