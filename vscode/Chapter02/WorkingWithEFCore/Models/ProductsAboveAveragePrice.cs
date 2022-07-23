using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore.Models
{
    [Keyless]
    public partial class ProductsAboveAveragePrice
    {
        [StringLength(40)]
        public string ProductName { get; set; } = null!;
        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }
    }
}
