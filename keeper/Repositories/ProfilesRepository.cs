using System.Data;
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
      return _db.QueryFirstOrDefault<Profile>(sql, new {userId});
    }
  }
}