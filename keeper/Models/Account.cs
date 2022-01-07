using keeper.Interfaces;

namespace keeper.Models
{
  public class Profile : IRepoItem<string>
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Picture { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
  }

  public class Account : Profile
  {
    public string Email { get; set; }
  }
}