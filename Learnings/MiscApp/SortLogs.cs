using System;
using System.Collections.Generic;

namespace MiscApp
{
    public class SortLogs
    {
        public static List<String> SortLogEntries(List<String> list)
        {
            List<string> strAlp = new List<string>();
            List<string> strNum = new List<string>();
            List<string> AlpNum = new List<string>();

            foreach (string sl in list)
            {
                string[] slPart = sl.Split(" ".ToCharArray(), 2);
                if (Char.IsDigit(slPart[1][0]))
                {
                    strNum.Add(sl);
                }
                else
                {
                    strAlp.Add(slPart[1] + " " + slPart[0]);
                }
            }
            strAlp.Sort();
            foreach (string sl2 in strAlp)
            {
                string part0 = sl2.Substring(0, sl2.LastIndexOf(" "));
                string part1 = sl2.Substring(sl2.LastIndexOf(" ") + 1);
                AlpNum.Add(part1 + " " + part0);
            }
            AlpNum.AddRange(strNum);
            return AlpNum;
        }
    }
}
