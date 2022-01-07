using System.Data;
using Dapper;
using keeper.Models;

namespace keeper.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Vault Create(Vault newVault)
    {
      string sql = @"
      INSERT INTO vaults
      (creatorId, name, description, isPrivate)
      VALUES
      (@CreatorId, @Name, @Description, @IsPrivate);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newVault);
      newVault.Id = id;
      return newVault;
    }

    internal Vault GetById(int id)
    {
      string sql = @"
      SELECT 
            vs.*,
            a.*
        FROM vaults vs
        JOIN accounts a ON vs.creatorId = a.id
        WHERE vs.id = @id;
      ";
      return _db.QueryFirstOrDefault<Vault>(sql, new { id });
    }
  }
}