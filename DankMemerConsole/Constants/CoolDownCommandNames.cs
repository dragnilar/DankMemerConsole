using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DankMemerConsole.Constants
{
    public static class CoolDownCommandNames
    {
        public const string PlsBeg = "pls beg";
        public const string PlsSearch = "pls search";
        public const string PlsFish = "pls fish";
        public const string PlsHunt = "pls hunt";
        public const string PlsDig = "pls dig";
        public const string PlsCrime = "pls crime";
        public const string PlsHighLow = "pls hl";
        public const string PlsPm = "pls pm";

        public static List<string> CommandNames = new List<string>
        {
            PlsBeg, PlsCrime, PlsDig, PlsFish, PlsHighLow, PlsHunt, PlsPm, PlsSearch
        };
    }
}
