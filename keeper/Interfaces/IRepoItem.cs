using keeper.Models;

namespace keeper.Interfaces
{
  public interface IRepoItem<T>
  {
    T Id { get; set; }
    string CreatorId { get; set; }

    Profile Creator { get; set; }

  }

}