using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Repositories;

namespace Services
{
   public class KeepsService
   {
      private readonly KeepsRepository _kRepo;
      private readonly VaultsRepository _vRepo;

      public KeepsService(KeepsRepository kRepo, VaultsRepository vRepo)
      {
         _kRepo = kRepo;
         _vRepo = vRepo;
      }

      public Keep CreateKeep(Keep newKeep)
      {
         newKeep.Id = _kRepo.CreateKeep(newKeep);
         return newKeep;
      }

      internal IEnumerable<Keep> GetAll()
      {
         IEnumerable<Keep> keep = _kRepo.Get();
         return keep.ToList();
      }

      internal Keep Get(int id)
      {
         Keep original = _kRepo.Get(id);
         Keep edited = original;
         edited.Views++;
         edited = _kRepo.Edit(edited);
         if (original == null)
         {
            throw new Exception("Invalid Id");
         }
         return edited;
      }

      internal Keep Edit(Keep editData, string userId)
      {
         Keep original = Get(editData.Id);
         if (original.CreatorId != userId)
         {
            throw new Exception("You cannot edit something you did not create");
         }
         editData.Name = editData.Name == null ? original.Name : editData.Name;
         editData.Description = editData.Description == null ? original.Description : editData.Description;
         return _kRepo.Edit(editData);
      }

      internal string Delete(int id, string userId)
      {
         Keep original = Get(id);
         if (original.CreatorId != userId)
         {
            throw new Exception("You cannot delete something you did not create");
         }
         _kRepo.Remove(id);
         return "Successsfully Deleted";
      }

      internal IEnumerable<VaultKeepViewModel> GetByVaultId(int id)
      {
         IEnumerable<VaultKeepViewModel> keeps = _kRepo.GetByVaultId(id);
         return keeps.ToList();
      }

      internal IEnumerable<Keep> GetKeepsByProfileId(string id)
      {
         IEnumerable<Keep> keeps = _kRepo.GetByCreatorId(id);
         return keeps.ToList();
      }

      internal IEnumerable<Keep> GetKeepsByAccountId(string id)
      {
         return _kRepo.GetByCreatorId(id);
      }
   }
}