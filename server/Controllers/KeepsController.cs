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
   public class KeepsController : ControllerBase
   {
      private readonly KeepsService _ks;

      public KeepsController(KeepsService ks)
      {
         _ks = ks;
      }

      [HttpPost]
      [Authorize]
      public async Task<ActionResult<Keep>> CreateKeep([FromBody] Keep newKeep)
      {
         try
         {
            Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
            newKeep.CreatorId = userInfo.Id;
            Keep created = _ks.CreateKeep(newKeep);
            created.Creator = userInfo;
            return created;
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
            throw;
         }
      }

      [HttpGet]
      public ActionResult<IEnumerable<Keep>> get()
      {
         try
         {
            return Ok(_ks.GetAll());
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }

      [HttpGet("{id}")]
      public ActionResult<Keep> Get(int id)
      {
         try
         {
            return Ok(_ks.Get(id));
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }

      [Authorize]
      [HttpPut("{id}")]
      public async Task<ActionResult<Keep>> Edit(int id, [FromBody] Keep editData)
      {
         try
         {
            Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
            editData.Id = id;
            editData.Creator = userInfo;
            editData.CreatorId = userInfo.Id;
            return Ok(_ks.Edit(editData, userInfo.Id));
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }

      [Authorize]
      [HttpDelete("{id}")]
      public async Task<ActionResult<string>> Delete(int id)
      {
         try
         {
            Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
            return Ok(_ks.Delete(id, userInfo.Id));
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }
   }
}