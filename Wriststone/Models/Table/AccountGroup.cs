using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wriststone.Models.Table
{
    [Table("account_group", Schema = "public")]
    public class AccountGroup
    {
        [Column("id")] public long? Id { get; set; }
        [Column("name")] public string Name { get; set; }
    }
}