using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Models.Table;

namespace Wriststone.Models.ViewModel
{
    public class ProductOrderModel
    {
        public Product Product { get; set; }
        public OrderDetails OrderDetails { get; set; }
    }
}
