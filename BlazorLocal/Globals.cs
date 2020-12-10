using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLocal
{
    public static class Globals
    {
        public static Dictionary<string, string> FahrzeugstatusDictionary => InitFahrzeugstatusDictionary();
        public static Dictionary<string, string> FahrzeugtypDictionary => InitFahrzeugtypDictionary();
        public static Dictionary<string, string> BaureiheDictionary => InitBaureiheDictionary();

        private static Dictionary<string, string> InitFahrzeugstatusDictionary()
        {
            var dic = new Dictionary<string, string>
            {
                {"190", "190"},
                {"193", "193"}
            };

            return dic;
        }

        private static Dictionary<string, string> InitFahrzeugtypDictionary()
        {
            var dic = new Dictionary<string, string>
            {
                {"Touring", "Touring"},
                {"Limousine", "Limousine"}
            };

            return dic;
        }

        private static Dictionary<string, string> InitBaureiheDictionary()
        {
            var dic = new Dictionary<string, string>
            {
                {"F01", "F01"},
                {"F02", "F02"},
                {"F03", "F03"},
                {"F04", "F04"},
                {"F05", "F05"},
                {"F06", "F06"},
                {"F07", "F07"},
                {"F08", "F08"},
                {"F09", "F09"},
                {"F10", "F10"},
                {"F11", "F11"},
                {"F12", "F12"}
            };

            return dic;
        }
    }
}
