using System.Data;
using Dapper;
using keeper.Models;

namespace keeper.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal VaultKeep Create(VaultKeep newVaultKeep)
    {
      string sql = @"
      INSERT INTO vaultKeeps
      (vaultId, keepId)
      VALUES
      (@VaultId, @KeepId);
      SELECT LAST_INSERT_ID()

      ;";
      newVaultKeep.Id = _db.ExecuteScalar<int>(sql, newVaultKeep);
      return newVaultKeep;
    }
  }
}