using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Common;
using api.Models;

namespace api.Interfaces
{
    public interface IFMPService
    {
        Task<Result<Stock>> FindBySymbolAsync(string symbol);
    }
}