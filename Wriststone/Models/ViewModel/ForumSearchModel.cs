using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wriststone.Models.ViewModel
{
    public class ForumSearchModel
    {
        public IEnumerable<ThreadSearchModel> Threads { get; set; }
        public string Search { get; set; }
        public long Pages { get; set; }
        public long Page { get; set; }
    }
}
