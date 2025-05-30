using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Application.Interfaces.UseCases;
using api.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.WebApi.Controllers
{
    [Route("api/portfolio")]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _PortfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _PortfolioService = portfolioService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePortfolio(string NamePortfolio)
        {
            var username = User.getUserName();

            var result = await _PortfolioService.CreatePortfolio(username, NamePortfolio);

            if (!result.Exit) return StatusCode(result.Errorcode, result.Errormessage);

            return CreatedAtAction(nameof(GetPortfolio), new { id = result.Data.IdPortfolio }, result.Data);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetPortfolio([FromRoute] int id)
        {
            var username = User.getUserName();

            var result = await _PortfolioService.GetPortfolioByID(username, id);

            if (!result.Exit) return StatusCode(result.Errorcode, result.Errormessage);

            return Ok(result.Data);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllPortfolios()
        {
            var username = User.getUserName();

            var result = await _PortfolioService.GetALL(username);

            if (!result.Exit) return StatusCode(result.Errorcode, result.Errormessage);

            return Ok(result.Data);
        }

        [HttpPost("{portfolioId}")]
        [Authorize]
        public async Task<IActionResult> AddStockToPortfolio(string symbol, [FromRoute] int portfolioId)
        {
            var username = User.getUserName();

            var result = await _PortfolioService.AddStock(username, symbol, portfolioId);

            if (!result.Exit) return StatusCode(result.Errorcode, result.Errormessage);

            return Ok();
        }

        [HttpDelete("{portfolioId}")]
        [Authorize]
        public async Task<IActionResult> DeleteStockFromPortfolio(string symbol, [FromRoute] int portfolioId)
        {
            var username = User.getUserName();

            var result = await _PortfolioService.DeleteStock(username, symbol, portfolioId);

            if (!result.Exit) return StatusCode(result.Errorcode, result.Errormessage);

            return NoContent();
        }
    }
}