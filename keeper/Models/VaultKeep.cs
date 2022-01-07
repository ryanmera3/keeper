using keeper.Interfaces;

namespace keeper.Models
{
  public class VaultKeep : IProfileItem
  {
    public int Id { get; set; }

    public string CreatorId { get; set; }

    public int VaultId { get; set; }

    public int KeepId { get; set; }
    public Profile Creator { get; set; }
  }
}