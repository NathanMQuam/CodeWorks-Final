using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Repositories;

namespace Services
{
   public class ProfilesService
   {
      private readonly ProfilesRepository _repo;
      private readonly KeepsRepository _kRepo;
      private readonly VaultsRepository _vRepo;

      public ProfilesService(ProfilesRepository repo, KeepsRepository kRepo, VaultsRepository vRepo)
      {
         _repo = repo;
         _kRepo = kRepo;
         _vRepo = vRepo;
      }

      internal Profile GetOrCreateProfile(Profile userInfo)
      {
         Profile profile = _repo.GetById(userInfo.Id);
         if (profile == null)
         {
            return _repo.Create(userInfo);
         }
         return profile;
      }

      internal Profile GetProfileById(string id)
      {
         Profile profile = _repo.GetById(id);
         if (profile == null)
         {
            throw new Exception("Invalid Id");
         }
         return profile;
      }

      internal IEnumerable<Keep> GetKeepsByProfileId(string id)
      {
         return _kRepo.GetByCreatorId(id);
      }

      internal IEnumerable<Vault> GetVaultsByProfileId(string id)
      {
         return _vRepo.GetByCreatorId(id).ToList().FindAll(v => !v.IsPrivate);
      }
   }
}