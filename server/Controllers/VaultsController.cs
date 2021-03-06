using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class VaultsController : ControllerBase
   {
      private readonly VaultsService _vs;
      private readonly KeepsService _ks;

      public VaultsController(VaultsService vs, KeepsService ks)
      {
         _vs = vs;
         _ks = ks;
      }

      [HttpGet]
      public ActionResult<IEnumerable<Vault>> Get()
      {
         try
         {
            return Ok(_vs.GetAll());
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         };
      }

      [HttpGet("{id}")]
      public async Task<ActionResult<Vault>> GetAsync(int id)
      {
         try
         {
            Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
            Vault data = _vs.Get(id);
            if (data.IsPrivate && data.CreatorId != userInfo.Id)
            {
               return BadRequest();
            }
            return Ok(data);
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         };
      }

      [HttpPost]
      [Authorize]
      public async Task<ActionResult<Vault>> Post([FromBody] Vault newVault)
      {
         try
         {
            Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
            newVault.CreatorId = userInfo.Id;
            Vault created = _vs.Create(newVault);
            created.Creator = userInfo;
            return Ok(created);
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }

      [HttpPut("{id}")]
      [Authorize]
      public async Task<ActionResult<Vault>> Edit(int id, [FromBody] Vault editData)
      {
         try
         {
            Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
            editData.Id = id;
            editData.Creator = userInfo;
            editData.CreatorId = userInfo.Id;
            return Ok(_vs.Edit(editData, userInfo.Id));
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
            return Ok(_vs.Delete(id, userInfo.Id));
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }

      [HttpGet("{id}/keeps")]
      public async Task<ActionResult<IEnumerable<VaultKeepViewModel>>> GetKeepsByVaultIdAsync(int id)
      {
         try
         {
            Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
            Vault v = _vs.Get(id);
            if (v.IsPrivate && v.CreatorId != userInfo.Id)
            {
               return BadRequest();
            }
            return Ok(_ks.GetByVaultId(id));
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }
   }
}