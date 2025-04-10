using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Extensions;
using api.Interfaces;
using api.Models;
using api.Repository;
using api.Services.HoldingService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [Route("api/holding")]
    public class HoldingController : ControllerBase
    {
        private readonly IHoldingService _HoldingService;

        public HoldingController(IHoldingService holdingService)
        {
            _HoldingService = holdingService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserHolding()
        {
            var username = User.getUserName();
            var result = await _HoldingService.GetHoldingUser(username);

            if (result.Exit == false) return StatusCode(result.Errorcode, result.Errormessage);

            return Ok(result.Data);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> AddStock(string symbol)
        {
            var username = User.getUserName();
            var result = await _HoldingService.AddStock(username, symbol);

            if (result.Exit == false) return StatusCode(result.Errorcode, result.Errormessage);

            return Ok(result.Data);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteStock(string symbol)
        {
            var username = User.getUserName();
            var result = await _HoldingService.DeleteStock(username, symbol);

            if (result.Exit == false) return StatusCode(result.Errorcode, result.Errormessage);

            return Ok(result.Data);
        }

    }
}