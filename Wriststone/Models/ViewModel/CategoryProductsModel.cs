using System.Collections.Generic;
using Wriststone.Models.Table;

namespace Wriststone.Models.ViewModel
{
    public class CategoryProductsModel
    {
        public IEnumerable<CategoryProductModel> Products { get; set; }
        public IEnumerable<ProductCategory> Categories { get; set; }
        public ProductCategory Category { get; set; }
        public string Search { get; set; }
        public long Pages { get; set; }
        public long Page { get; set; }
    }
}