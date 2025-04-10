using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using api.Common;
using api.DTOs.Stock;
using api.Interfaces;
using api.mappers;
using api.Models;
using Newtonsoft.Json;

namespace api.Services.FMPconnectorService
{
    public class FMPService : IFMPService
    {
        private HttpClient _HttpClient;
        private IConfiguration _Config;

        public FMPService(HttpClient httpClient, IConfiguration config)
        {
            _HttpClient = httpClient;
            _Config = config;
        }


        public async Task<Result<Stock>> FindBySymbolAsync(string symbol)
        {
            try
            {
                var result = await _HttpClient.GetAsync($"https://financialmodelingprep.com/api/v3/profile/{symbol}?apikey={_Config["FMPkey"]}");

                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var tasks = JsonConvert.DeserializeObject<FMPstockDto[]>(content);
                    var Stock = tasks[0];

                    if (Stock != null)
                    {
                        return Result<Stock>.Exito(Stock.TOstockFromFMP());
                    }

                    return Result<Stock>.Error("stock not found", (int)result.StatusCode);
                }
                return Result<Stock>.Error("something went wrong", (int)result.StatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Result<Stock>.Error("something went wrong", 500);
            }
        }
    }
}