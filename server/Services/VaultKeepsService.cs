using System;
using Models;
using Repositories;

namespace Services
{
   public class VaultKeepsService
   {
      private readonly VaultKeepsRepository _vkRepo;
      private readonly KeepsRepository _kRepo;

      public VaultKeepsService(VaultKeepsRepository vkRepo, KeepsRepository kr)
      {
         _vkRepo = vkRepo;
         _kRepo = kr;
      }

      internal VaultKeep CreateVaultKeep(VaultKeep newVaultKeep)
      {
         newVaultKeep.Id = _vkRepo.Create(newVaultKeep);
         Keep vKeep = _kRepo.Get(newVaultKeep.KeepId);
         vKeep.Keeps++;
         _kRepo.Edit(vKeep);
         return newVaultKeep;
      }

      internal void Delete(int id, string userId)
      {
         VaultKeep original = Get(id);
         if (original.CreatorId != userId)
         {
            throw new Exception("You cannot delete something you did not create");
         }
         _vkRepo.Remove(id);
      }

      private VaultKeep Get(int id)
      {
         VaultKeep vk = _vkRepo.Get(id);
         return vk;
      }
   }
}