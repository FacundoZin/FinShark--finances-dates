using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Stock
{
    public class UpdateStockDto
    {
        [Required]
        [MaxLength(15, ErrorMessage = "Symbol cannot be over 15 over characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(20, ErrorMessage = "Company Name cannot be over 20 over characters")]
        public string Companyname { get; set; } = string.Empty;
        [Required]
        [Range(1, 1000000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Industry cannot be over 20 characters")]
        public string Industry { get; set; } = string.Empty;
        [Range(1, 5000000000)]
        public long MarketCap { get; set; }
    }
}