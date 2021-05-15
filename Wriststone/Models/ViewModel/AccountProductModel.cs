using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Models.Table;

namespace Wriststone.Models.ViewModel
{
    public class AccountProductModel
    {
        public Product Product { get; set; }
        public Order Order { get; set; }
        public OrderDetails OrderDetails { get; set; }
        public Currency Currency { get; set; }
    }
}
