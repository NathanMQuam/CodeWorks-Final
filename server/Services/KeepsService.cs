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

      public KeepsService(KeepsRepository kRepo)
      {
         _kRepo = kRepo;
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
         if (original == null)
         {
            throw new Exception("Invalid Id");
         }
         return original;
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

      // TODO: Get by Keep Id
      // TODO: Get by Creator Id
   }
}