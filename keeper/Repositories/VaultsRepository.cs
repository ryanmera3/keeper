using System.Collections.Generic;
using System.Data;
using System.Linq;
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

    public Vault GetById(int id)
    {
      string sql = @"
      SELECT 
            vs.*,
            a.*
        FROM vaults vs
        JOIN accounts a ON vs.creatorId = a.id
        WHERE vs.id = @id;
      ";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, prof) =>
      {
        vault.Creator = prof;
        return vault;
      }, new { id }).FirstOrDefault();
    }

    internal void Edit(Vault original)
    {
      string sql = @"
      UPDATE vaults
      SET
        name = @Name,
        description = @Description,
        isPrivate = @IsPrivate
    Where id = @Id;
      ";
      _db.Execute(sql, original);
    }

    internal List<Vault> GetByCreatorId(string id)
    {
      string sql = @"
      SELECT
        v.*,
        a.*
      FROM vaults v
      JOIN accounts a ON v.creatorId = a.id
      WHERE v.creatorId = @id;
      ";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, prof) =>
      {
        vault.Creator = prof;
        return vault;
      }, new{id}).ToList();
    }

    internal void Delete(int id)
    {
      string sql = @"DELETE FROM vaults WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }

    internal List<Vault> GetMyVaults(string id)
    {
      string sql = @"
      SELECT
        v.*,
        a.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId
      WHERE a.id = @id;
      ";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
      {
        vault.Creator = profile;
        return vault;
      }, new {id}).ToList();
    }
  }
}