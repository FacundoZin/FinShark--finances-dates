using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Common;
using api.Models;

namespace api.Interfaces
{
    public interface IHoldingRepository
    {
        Task<List<Stock>?> GetHoldingByUser(AppUser User);
        Task<bool> AddStockToHolding(AppUser User, Stock stock);
        Task<bool> DeleteStock(AppUser user, Stock stock);
    }
}