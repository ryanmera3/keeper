using keeper.Models;

namespace keeper.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _pRepo;

    public ProfilesService(ProfilesRepository pRepo)
    {
      _pRepo = pRepo;
    }

    internal Profile GetProfile(string userId)
    {
      return _pRepo.GetProfile(userId);
    }
  }
}