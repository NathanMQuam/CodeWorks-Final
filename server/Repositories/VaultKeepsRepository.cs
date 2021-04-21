using System;
using System.Data;
using System.Linq;
using Dapper;
using Models;

namespace Repositories
{
   public class VaultKeepsRepository
   {
      private readonly IDbConnection _db;

      public VaultKeepsRepository(IDbConnection db)
      {
         _db = db;
      }

      internal int Create(VaultKeep newVaultKeep)
      {
         string sql = @"
            UPDATE keeps
            SET keeps = keeps + 1
            WHERE id = @KeepId;

            INSERT INTO vaultkeeps
            (creatorId, vaultId, keepId)
            VALUES
            (@CreatorId, @VaultId, @KeepId);

            SELECT LAST_INSERT_ID()";
         return _db.ExecuteScalar<int>(sql, newVaultKeep);
      }

      internal void Remove(int id)
      {
         string sql = @"DELETE FROM vaultkeeps WHERE id = @id LIMIT 1;";
         _db.Execute(sql, new { id });
      }

      internal VaultKeep Get(int id)
      {
         string sql = @"SELECT vaultKeeps.*,
                        profile.*
                        FROM vaultkeeps
                        JOIN profiles profile ON vaultKeeps.creatorId = profile.id
                        WHERE vaultKeeps.id = @id;";
         return _db.Query<VaultKeep, Profile, VaultKeep>(sql, (vaultKeep, profile) =>
         {
            vaultKeep.Creator = profile;
            return vaultKeep;
         }, new { id }, splitOn: "id").FirstOrDefault();
      }
   }
}