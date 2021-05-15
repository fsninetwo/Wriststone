using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wriststone.Models.Table
{
    [Table("product_currency", Schema = "public")]
    public class ProductCurrency
    {
        [Column("id")] public long? Id { get; set; }
        [Column("price")] public decimal? Price { get; set; }
        [Column("product_id")] public long? Product { get; set; }
        [Column("currency_id")] public long? Currency { get; set; }
    }
}