using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Repositories;

namespace Services
{
   public class VaultsService
   {
      private readonly VaultsRepository _repo;
      public VaultsService(VaultsRepository repo)
      {
         _repo = repo;
      }

      public IEnumerable<Vault> GetAll()
      {
         IEnumerable<Vault> vaults = _repo.GetAll();
         return vaults;
      }

      internal Vault Get(int id)
      {
         var data = _repo.Get(id);
         if (data == null)
         {
            throw new Exception("Invalid Id");
         }
         return data;
      }


      public Vault Create(Vault newVault)
      {
         newVault.Id = _repo.Create(newVault);
         return newVault;
      }

      internal Vault Edit(Vault editData, string userId)
      {
         Vault original = Get(editData.Id);
         if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot Edit a Vault You did not Create"); }
         editData.Name = editData.Name == null ? original.Name : editData.Name;
         editData.Description = editData.Description == null ? original.Description : editData.Description;

         return _repo.Edit(editData);
      }

      internal string Delete(int id, string userId)
      {
         Vault original = Get(id);
         if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot Delete a Vault You did not Create"); }
         _repo.Remove(id);
         return "successfully deleted";
      }
   }
}