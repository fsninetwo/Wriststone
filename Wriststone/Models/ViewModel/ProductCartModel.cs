using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Models.Table;

namespace Wriststone.Models.ViewModel
{
    public class ProductCartModel
    {
        public Product Product { get; set; }
        public ProductCurrency ProductCurrency { get; set; }
        public Currency Currency { get; set; }
    }
}
