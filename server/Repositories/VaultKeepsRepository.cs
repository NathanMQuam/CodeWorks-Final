using System;
using System.Data;
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
         string sql = @"INSERT INTO vaultkeeps
            (creatorId, vaultId, keepId)
            VALUES
            (@CreatorId, @VaultId, @KeepId);
            SELECT LAST_INSERT_ID()";
         return _db.ExecuteScalar<int>(sql, newVaultKeep);
      }

      internal void Remove(int id)
      {
         throw new NotImplementedException();
      }
   }
}