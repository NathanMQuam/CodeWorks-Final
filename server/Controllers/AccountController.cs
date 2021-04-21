using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Collections;
using System.Collections.Generic;

namespace Controllers
{
   [ApiController]
   [Route("[controller]")]

   // REVIEW this tag enforces the user must be logged in
   [Authorize]
   public class AccountController : ControllerBase
   {
      private readonly ProfilesService _pservice;
      private readonly KeepsService _ks;
      private readonly VaultsService _vs;

      public AccountController(ProfilesService pservice, KeepsService ks, VaultsService vs)
      {
         _pservice = pservice;
         _ks = ks;
         _vs = vs;
      }

      [HttpGet]
      // REVIEW async calls must return a System.Threading.Tasks, this is equivalent to a promise in JS
      public async Task<ActionResult<Profile>> GetAsync()
      {
         try
         {
            // REVIEW how to get the user info from the request token
            // same as to req.userInfo
            //MAKE SURE TO BRING IN codeworks.auth0provider
            Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
            return Ok(_pservice.GetOrCreateProfile(userInfo));
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }

      [HttpGet("keeps")]
      public async Task<ActionResult<IEnumerable<Keep>>> GetKeepsAsync()
      {
         try
         {
            Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
            return Ok(_ks.GetKeepsByAccountId(userInfo.Id));
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }

      [HttpGet("vaults")]
      public async Task<ActionResult<IEnumerable<Vault>>> GetVaultsAsync()
      {
         try
         {
            Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
            return Ok(_vs.GetVaultsByAccountId(userInfo.Id));
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }
   }
}