using System.Collections.Generic;
using Wriststone.Models.Table;

namespace Wriststone.Models.ViewModel
{
    public class ThreadPostsModel
    {
        public Account Creator { get; set; }
        public Thread Thread { get; set; }
        public long Post { get; set; }
        public IEnumerable<AccountPostModel> Posts { get; set; }
        public long Pages { get; set; }
        public long Page { get; set; }
    }
}