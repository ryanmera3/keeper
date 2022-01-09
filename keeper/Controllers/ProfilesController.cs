using System;
using System.Collections.Generic;
using keeper.Models;
using keeper.Services;
using Microsoft.AspNetCore.Mvc;

namespace keeper.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly AccountService _accountService;
    private readonly VaultsService _vs;

    private readonly KeepsService _ks;

    public ProfilesController(AccountService accountService, VaultsService vs, KeepsService ks)
    {
      _accountService = accountService;
      _vs = vs;
      _ks = ks;
    }



    // [HttpGet]
    // public async Task<ActionResult<Profile>> GetProfile(string id)
    // {
    //   try
    //   {
    //        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
    //        return Ok(_accountService.GetProfile(userInfo));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    [HttpGet("{id}/vaults")]
    public ActionResult<List<Vault>> GetVaultsByProfileId(string id)
    {
      try
      {
           List<Vault> vaults = _vs.GetByCreatorId(id);
           return Ok(vaults);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/keeps")]
    public ActionResult<List<Keep>> GetKeepsByProfileId(string id)
    {
      try
      {
           List<Keep> keeps = _ks.GetByCreatorId(id);
           return Ok(keeps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}