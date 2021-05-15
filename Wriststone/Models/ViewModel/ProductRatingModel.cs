using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wriststone.Models.ViewModel
{
    public class ProductRatingModel
    {
        public List<AccountRatingModel> Ratings { get; set; }
        public long Page { get; set; }
        public long Pages { get; set; }
        public long RatingId { get; set; }
    }
}
