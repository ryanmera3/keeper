using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keeper.Models;

namespace keeper.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Keep Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keeps
      (creatorId, name, description, img, views, shares, keeps)
      VALUES
      (@CreatorId, @Name, @Description, @Img, @Views, 0, @Keeps);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newKeep);
      newKeep.Id = id;
      return newKeep;
    }

    public Keep GetById(int id)
    {
      string sql = @"
        SELECT 
            ks.*,
            a.*
        FROM keeps ks
        JOIN accounts a ON ks.creatorId = a.id
        WHERE ks.id = @id;
      ";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, prof) =>
     {
       keep.Creator = prof;
       return keep;
     }, new { id }).FirstOrDefault();
    }

    public List<Keep> GetAll()
    {
      string sql = @"
      SELECT 
        ks.*,
        a.* 
      FROM keeps ks
      JOIN accounts a ON ks.creatorId = a.id";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, prof) =>
      {
        keep.Creator = prof;
        return keep;
      }).ToList();
    }

    internal void Edit(Keep original)
    {
      string sql = @"
      UPDATE keeps
      SET
        description = @Description,
        name = @Name,
        img = @Img
      WHERE id = @Id;
      ";
      _db.Execute(sql, original);
    }

    internal void Delete(int id)
    {
      string sql = @"DELETE FROM keeps WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}