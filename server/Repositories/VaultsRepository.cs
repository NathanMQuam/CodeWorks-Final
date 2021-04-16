using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Models;

namespace Repositories
{
   public class VaultsRepository
   {
      private readonly IDbConnection _db;

      public VaultsRepository(IDbConnection db)
      {
         _db = db;
      }

      internal IEnumerable<Vault> GetAll()
      {
         string sql = @"
            SELECT 
            vault.*,
            profile.* 
            FROM vaults vault 
            JOIN profiles profile ON vault.creatorId = profile.id;";
         return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
         {
            vault.Creator = profile; return vault;
         }, splitOn: "id");
      }

      internal Vault Get(int id)
      {
         string sql = @"
            SELECT 
            vault.*,
            profile.* 
            FROM vaults vault 
            JOIN profiles profile ON vault.creatorId = profile.id
            WHERE vault.id = @id;";
         return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
         {
            vault.Creator = profile; return vault;
         }, new { id }, splitOn: "id").FirstOrDefault();
      }


      internal int Create(Vault VaultData)
      {
         string sql = @"
            INSERT INTO Vaults
            (name, creatorId, description, isPrivate)
            VALUES
            (@Name, @CreatorId, @Description, @IsPrivate);
            SELECT LAST_INSERT_ID()";
         return _db.ExecuteScalar<int>(sql, VaultData);
      }

      internal Vault Edit(Vault editData)
      {
         string sql = @"
            UPDATE vaults
            SET 
            name = @Name,
            description = @Description,
            isPrivate = @IsPrivate
            WHERE id = @Id;";
         _db.Execute(sql, editData);
         return editData;
      }

      internal void Remove(int id)
      {
         string sql = "DELETE FROM vaults WHERE id = @id LIMIT 1";
         _db.Execute(sql, new { id });
      }
   }
}