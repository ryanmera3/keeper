using keeper.Repositories;

namespace keeper.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vkRepo;

    public VaultKeepsService(VaultKeepsRepository vkRepo)
    {
      _vkRepo = vkRepo;
    }
  }
}