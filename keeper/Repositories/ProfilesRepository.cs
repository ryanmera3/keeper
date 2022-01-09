using System.Data;
using System.Linq;
using Dapper;
using keeper.Models;

namespace keeper.Services
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Profile GetProfile(string userId)
    {
      string sql = @"
      SELECT * FROM accounts WHERE id = @userId;
      ";
      return _db.Query<Profile, Account, Profile>(sql, (prof, acct) =>
      {
        prof.Id = acct.Id;
        prof.Name = acct.Name;
        prof.Picture = acct.Picture;
        return prof;
      },new {userId}, splitOn:"CreatorId").FirstOrDefault();
    }
  }
}