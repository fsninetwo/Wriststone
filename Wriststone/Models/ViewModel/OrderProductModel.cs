using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Models.Table;

namespace Wriststone.Models.ViewModel
{
    public class OrderProductModel
    {
        public Order Order { get; set; }
        public Currency Currency { get; set; }
        public List<ProductOrderModel> Orders { get; set; }
    }
}
