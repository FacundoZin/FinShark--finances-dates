using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{

    public interface IStockRepository
    {
        IQueryable<Stock> GetAllStocks();
        Task<Stock?> Getbyidasync(int id);
        Task<Stock?> GetbySymbolAsync(string symbol);
        Task<Stock?> Createasync(Stock stock);
        Task<Stock?> Updateasync(int id, UpdateStockDto updatedstock);
        Task<Stock?> Deleteasync(int id);
        Task<bool> StockExist(int id);
    }
}