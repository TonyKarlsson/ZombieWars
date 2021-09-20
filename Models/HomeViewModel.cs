namespace ZombieWars.Models
{
  public class HomeViewModel
  {
    public HomeViewModel()
    {
      Monster = new ZombieModel(50, 20);
      User = new UserModel();

    }
    public IMonsterModel Monster { get; set; }

    public UserModel User { get; set; }
  }

  // Add colors to actions => Red for danger and taking damage, green for money
  // When Hp < 30, make text red?
  // Make open chest button => random money and later on stuff
  // Make partials and CSS Grid those fuckers
  // Monster card

  }