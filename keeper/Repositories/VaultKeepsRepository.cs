using System.Data;
using System.Linq;
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
      UPDATE keeps k
        SET keeps = keeps + 1
        WHERE k.id = @KeepId;
      INSERT INTO vaultKeeps
      (vaultId, creatorId, keepId)
      VALUES
      (@VaultId,@CreatorId, @KeepId);
      SELECT LAST_INSERT_ID()

      ;";
      newVaultKeep.Id = _db.ExecuteScalar<int>(sql, newVaultKeep);
      return newVaultKeep;
    }

    public VaultKeep GetById(int id)
    {
      string sql = @"
                SELECT
                vk.*
                FROM
                vaultKeeps vk
                WHERE
                vk.id = @id;
            ";

      return _db.Query<VaultKeep>(sql, new { id }).FirstOrDefault();
    }

    public void Delete(int id)
    {
      var sql = "DELETE FROM vaultKeeps WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}