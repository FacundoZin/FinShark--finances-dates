using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Common;
using api.DTOs.Stock;
using api.Helpers;
using api.Models;

namespace api.Services.StockService
{
    public interface IStockService
    {
        Task<List<StockDto?>> GetAllStocksAsync(StockQueryObject queryObject);
        Task<Result<StockDto?>> GetStockByIdAsync(int id);
        Task<Result<Stock>> CreateStockAsync(CreateStockDto createStock);
        Task<Result<Stock?>> DeleteStockAsync(int id);
        Task<Result<StockDto?>> UpdateStockAsync(int id, UpdateStockDto updateStockDto);
    }
}