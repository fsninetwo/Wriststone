using System.Collections.Generic;
using Wriststone.Models.Table;

namespace Wriststone.Models.ViewModel
{
    public class CategoryThreadsModel
    {
        public ForumCategory Category { get; set; }
        public IEnumerable<ThreadInfoModel> Threads { get; set; }
        public IEnumerable<ForumCategory> Categories { get; set; }
        public long Pages { get; set; }
        public long Page { get; set; }
    }
}