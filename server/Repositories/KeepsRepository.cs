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
            keeps.id,
            keeps.creatorId,
            keeps.name,
            keeps.description,
            keeps.image AS img,
            keeps.views,
            keeps.shares,
            keeps.keeps,
            profile.*
            FROM keeps
            JOIN profiles profile ON keeps.creatorId = profile.id;";
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
            keeps.id,
            keeps.creatorId,
            keeps.name,
            keeps.description,
            keeps.image AS img,
            keeps.views,
            keeps.shares,
            keeps.keeps,
            profile.*
            FROM keeps
            JOIN profiles profile ON keeps.creatorId = profile.id
            WHERE keeps.id = @id;";
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

      internal IEnumerable<Keep> GetByAccount(string id)
      {
         string sql = @"
            SELECT 
            keeps.id,
            keeps.creatorId,
            keeps.name,
            keeps.description,
            keeps.image AS img,
            keeps.views,
            keeps.shares,
            keeps.keeps,
            profiles.id,
            profiles.name AS creatorName,
            profiles.email,
            profiles.picture
            FROM keeps
            JOIN profiles ON keeps.creatorId = profiles.id
            WHERE keeps.creatorId = @id;";
         return _db.Query<Keep, Profile, Keep>(sql, (Keep, Profile) =>
         {
            Keep.Creator = Profile;
            return Keep;
         }, new { id }, splitOn: "id");
      }

      internal IEnumerable<VaultKeepViewModel> GetByVaultId(int id)
      {
         string sql = @"
            SELECT 
            keeps.id,
            keeps.creatorId,
            keeps.name,
            keeps.description,
            keeps.image AS img,
            keeps.views,
            keeps.shares,
            keeps.keeps,
            vaultkeeps.id AS vaultKeepId,
            profiles.id,
            profiles.name AS creatorName,
            profiles.email,
            profiles.picture
            FROM vaultKeeps
            JOIN keeps ON keeps.id = vaultKeeps.keepId
            JOIN profiles ON keeps.creatorId = profiles.id
            WHERE vaultId = @id;";
         return _db.Query<VaultKeepViewModel, Profile, VaultKeepViewModel>(sql, (VaultKeepViewModel, Profile) =>
         {
            VaultKeepViewModel.Creator = Profile;
            return VaultKeepViewModel;
         }, new { id }, splitOn: "id");
      }

      internal IEnumerable<Keep> GetByCreatorId(string id)
      {
         string sql = @"
            SELECT 
            keeps.id,
            keeps.creatorId,
            keeps.name,
            keeps.description,
            keeps.image AS img,
            keeps.views,
            keeps.shares,
            keeps.keeps,
            profile.*
            FROM keeps
            JOIN profiles profile ON keeps.creatorId = profile.id
            WHERE keeps.creatorId = @id;";
         return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
         {
            keep.Creator = profile;
            return keep;
         }, new { id }, splitOn: "id");
      }
   }
}