using System.Collections.Generic;
using Wriststone.Models.Table;

namespace Wriststone.Models.ViewModel
{
    public class ProductModel
    {
        public ProductCartModel Product { get; set; }
        public double Rate { get; set; }
        public Account Account { get; set; }
        public List<AccountRatingModel> Ratings { get; set; }
        public bool Bought { get; set; }
    }
}