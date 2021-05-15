using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wriststone.Models.Table
{
    [Table("account_status", Schema = "public")]
    public class AccountStatus
    {
        [Column("id")] public long? Id { get; set; }
        [Column("name")] public string Name { get; set; }
    }
}