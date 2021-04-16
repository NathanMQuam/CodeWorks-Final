using System.Data;
using System;
using Models;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
   public class KeepsRepository
   {
      private readonly IDbConnection _db;

      public KeepsRepository(IDbConnection db)
      {
         _db = db;
      }

      internal int CreateKeep(Keep newKeep)
      {
         string sql = @"
         INSERT INTO keeps
         (creatorId, name, description, image, views, shares, keeps)
         VALUES
         (@CreatorId, @Name, @Description, @Img, 0, 0, 0);
         SELECT LAST_INSERT_ID();";
         return _db.ExecuteScalar<int>(sql, newKeep);
      }

      internal IEnumerable<Keep> Get()
      {
         string sql = @"
            SELECT 
            keep.*,
            profile.*
            FROM keeps keep
            JOIN profiles profile ON keep.creatorId = profile.id;";
         return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
         {
            keep.Creator = profile;
            return keep;
         }, splitOn: "id");
      }

      internal Keep Get(int id)
      {
         string sql = @"
            SELECT 
            keep.*,
            profile.*
            FROM keeps keep
            JOIN profiles profile ON keep.creatorId = profile.id
            WHERE keep.id = @id;";
         return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
         {
            keep.Creator = profile;
            return keep;
         }, new { id }, splitOn: "id").FirstOrDefault();
      }

      internal Keep Edit(Keep editData)
      {
         string sql = @"
            UPDATE keeps
            SET 
            name = @Name,
            description = @Description
            WHERE id = @Id;";
         _db.Execute(sql, editData);
         return editData;
      }

      internal void Remove(int id)
      {
         string sql = "DELETE FROM keeps WHERE id = @id LIMIT 1;";
         _db.Execute(sql, new { id });
      }

      internal IEnumerable<Keep> GetByVaultId(int id)
      {
         string sql = @"
      SELECT 
      keeps.*,
      vaultKeeps.*,
      profiles.*
      FROM keeps
      JOIN vaultKeeps ON keeps.id = vaultKeeps.keepId
      JOIN profiles ON keeps.creatorId = profiles.id
      WHERE vaultKeeps.vaultId = @id;";
         return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
         {
            keep.Creator = profile;
            return keep;
         }, new { id }, splitOn: "id");
      }

      internal IEnumerable<Keep> GetByCreatorId(string id)
      {
         string sql = @"
      SELECT 
      keep.*,
      profile.*
      FROM keeps keep
      JOIN profiles profile ON keep.creatorId = profile.id
      WHERE keep.creatorId = @id;";
         return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
         {
            keep.Creator = profile;
            return keep;
         }, new { id }, splitOn: "id");
      }
   }
}