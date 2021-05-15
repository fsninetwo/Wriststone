using System;
using System.Collections.Generic;
using System.Linq;
using Wriststone.Models.Table;

namespace Wriststone.Models.ViewModel
{
    public class ThreadSearchModel
    {
        public Thread Thread { get; set; }
        public Account Creator { get; set; }
        public Account Poster { get; set; }
        public long? Posts { get; set; }
        public Post Post { get; set; }
    }
}
