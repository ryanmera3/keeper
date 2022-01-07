using keeper.Repositories;

namespace keeper.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _kRepo;

    public KeepsService(KeepsRepository kRepo)
    {
      _kRepo = kRepo;
    }
  }
}