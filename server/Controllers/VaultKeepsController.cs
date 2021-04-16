using Models;
using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System;
using CodeWorks.Auth0Provider;

namespace Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class VaultKeepsController : ControllerBase
   {
      private readonly KeepsService _ks;
      private readonly VaultsService _vs;
      private readonly VaultKeepsService _vks;

      public VaultKeepsController(KeepsService ks, VaultsService vs, VaultKeepsService vks)
      {
         _ks = ks;
         _vs = vs;
         _vks = vks;
      }

      [HttpPost]
      [Authorize]
      public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep newVaultKeep)
      {
         try
         {
            Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
            newVaultKeep.CreatorId = userInfo.Id;
            VaultKeep created = _vks.CreateVaultKeep(newVaultKeep);
            created.Creator = userInfo;
            return Ok(created);
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }

      [HttpDelete("{id}")]
      [Authorize]
      public async Task<ActionResult<string>> Delete(int id)
      {
         try
         {
            Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
            return Ok(_vks.Delete(id, userInfo.Id));
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }
   }
}