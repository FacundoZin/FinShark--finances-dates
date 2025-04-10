using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Common;
using api.DTOs.Stock;
using api.Models;

namespace api.Services.HoldingService
{
    public interface IHoldingService
    {
        Task<Result<List<StockDto>?>> GetHoldingUser(string username);
        Task<Result<AddedstockToHolding>> AddStock(string username, string symbol);
        Task<Result<Stock?>> DeleteStock(string username, string symbol);

    }
}