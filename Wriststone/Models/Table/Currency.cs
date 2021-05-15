using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wriststone.Models.Table
{
    [Table("currency", Schema = "public")]
    public class Currency
    {
        [Column("id")] public long? Id { get; set; }
        [Column("name")] public string Name { get; set; }
        [Column("symbol")] public string Symbol { get; set; }
    }
}