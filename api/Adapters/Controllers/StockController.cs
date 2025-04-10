using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Stock;
using api.Helpers;
using api.Interfaces;
using api.mappers;
using api.Models;
using api.Services.StockService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{

    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {

        private readonly IStockService _StockService;
        public StockController(IStockService stockService)
        {
            _StockService = stockService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] StockQueryObject query)
        {
            var stocks = await _StockService.GetAllStocksAsync(query);

            return Ok(stocks);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var Result = await _StockService.GetStockByIdAsync(id);

            if (Result.Exit == true)
            {
                return Ok(Result.Data);
            }
            else
            {
                return StatusCode(Result.Errorcode, Result.Errormessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockDto createStockDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stock = await _StockService.CreateStockAsync(createStockDto);

            if (stock.Exit == false)
            {
                return StatusCode(stock.Errorcode, stock.Errormessage);
            }
            return CreatedAtAction(nameof(GetByID), new { id = stock.Data.ID }, stock.Data.toStockDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockDto updatedStock)
        {
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest(ModelState);
            }

            var stock = await _StockService.UpdateStockAsync(id, updatedStock);

            if (stock.Exit == false)
            {
                StatusCode(stock.Errorcode, stock.Errormessage);
            }

            return Ok(stock.Data);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest("invalid ID");
            }

            var stock = await _StockService.DeleteStockAsync(id);

            if (stock.Exit == false)
            {
                return StatusCode(stock.Errorcode, stock.Errormessage);
            }

            return NoContent();
        }
    }
}
