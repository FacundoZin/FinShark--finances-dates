using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using api.DTOs.Stock;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.mappers
{
    public static class StockMapper
    {
        public static StockDto toStockDto(this Stock StockModel)
        {
            return new StockDto
            {
                ID = StockModel.ID,
                Symbol = StockModel.Symbol,
                Companyname = StockModel.Companyname,
                Purchase = StockModel.Purchase,
                LastDiv = StockModel.LastDiv,
                Industry = StockModel.Industry,
                MarketCap = StockModel.MarketCap,
                comments = StockModel.Comments.Select(c => c.toCommentdto()).ToList()
            };
        }

        public static Stock ToStockfromCreateDto(this CreateStockDto createStockDto)
        {
            return new Stock
            {
                Symbol = createStockDto.Symbol,
                Companyname = createStockDto.Companyname,
                Purchase = createStockDto.Purchase,
                LastDiv = createStockDto.LastDiv,
                Industry = createStockDto.Industry,
                MarketCap = createStockDto.MarketCap
            };
        }

        public static Stock TOstockFromFMP(this FMPstockDto _FMPstockDto)
        {
            return new Stock
            {
                Symbol = _FMPstockDto.symbol,
                Companyname = _FMPstockDto.companyName,
                Purchase = (decimal)_FMPstockDto.price,
                LastDiv = (decimal)_FMPstockDto.lastDiv,
                Industry = _FMPstockDto.industry,
                MarketCap = _FMPstockDto.mktCap
            };
        }

        public static AddedstockToHolding ToAddedStockHoldingfromStock(this Stock stock)
        {
            return new AddedstockToHolding
            {
                Symbol = stock.Symbol,
            };

        }

    }
}