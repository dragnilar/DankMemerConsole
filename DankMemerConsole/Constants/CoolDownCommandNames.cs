using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DankMemerConsole.Constants
{
    public static class CoolDownCommandNames
    {
        private static Dictionary<string, string> _aliasLookup;
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
        public static Dictionary<string, string> AliasLookup
        {
            get => _aliasLookup ??= GenerateAliasLookup();
            set => _aliasLookup = value;
        }



        private static Dictionary<string, string> GenerateAliasLookup()
        {
            var aliasDictionary =  new Dictionary<string, string>();
            aliasDictionary.Add("beg",PlsBeg);
            aliasDictionary.Add("search",PlsSearch);
            aliasDictionary.Add("fish",PlsFish);
            aliasDictionary.Add("hunt",PlsHunt);
            aliasDictionary.Add("dig",PlsDig);
            aliasDictionary.Add("crime",PlsCrime);
            aliasDictionary.Add("hl",PlsHighLow);
            aliasDictionary.Add("pm",PlsPm);
            aliasDictionary.Add("scout",PlsSearch);
            aliasDictionary.Add("cast",PlsFish);
            return aliasDictionary;
        }
    }
}
