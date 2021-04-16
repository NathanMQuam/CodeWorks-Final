using System;
using Models;
using Repositories;

namespace Services
{
   public class VaultKeepsService
   {
      private readonly VaultKeepsRepository _vkRepo;

      public VaultKeepsService(VaultKeepsRepository vkRepo)
      {
         _vkRepo = vkRepo;
      }

      internal VaultKeep CreateVaultKeep(VaultKeep newVaultKeep)
      {
         newVaultKeep.Id = _vkRepo.Create(newVaultKeep);
         return newVaultKeep;
      }

      internal object Delete(int id, string userId)
      {
         VaultKeep original = Get(id);
         if (original.CreatorId != userId)
         {
            throw new Exception("You cannot delete something you did not create");
         }
         _vkRepo.Remove(id);
         return "Successsfully Deleted";
      }

      private VaultKeep Get(int id)
      {
         throw new NotImplementedException();
      }
   }
}