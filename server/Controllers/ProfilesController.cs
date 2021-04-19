using Models;
using Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class ProfilesController : ControllerBase
   {
      private readonly ProfilesService _pservice;

      public ProfilesController(ProfilesService pservice, KeepsService ks, VaultsService vs)
      {
         _pservice = pservice;
      }

      [HttpGet("{id}")]
      public ActionResult<Profile> Get(string id)
      {
         try
         {
            return Ok(_pservice.GetProfileById(id));
         }
         catch (Exception err)
         {
            return BadRequest(err.Message);
         }
      }

      [HttpGet("{id}/keeps")]
      public ActionResult<IEnumerable<Keep>> GetUsersKeeps(string id)
      {
         try
         {
            return Ok(_pservice.GetKeepsByProfileId(id));
         }
         catch (Exception err)
         {
            return BadRequest(err.Message);
         }
      }

      [HttpGet("{id}/vaults")]
      public ActionResult<IEnumerable<Vault>> GetUsersVaults(string id)
      {
         try
         {
            return Ok(_pservice.GetVaultsByProfileId(id));
         }
         catch (Exception err)
         {
            return BadRequest(err.Message);
         }
      }
   }
}