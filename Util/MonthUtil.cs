using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_And_Company_Management.Util
{
    public class MonthUtil
    {
        public static List<string> Months { get; } = new List<string>
        {
            LanguageUtil.Translate("January"),
            LanguageUtil.Translate("February"),
            LanguageUtil.Translate("March"),
            LanguageUtil.Translate("April"),
            LanguageUtil.Translate("May"),
            LanguageUtil.Translate("June"),
            LanguageUtil.Translate("July"),
            LanguageUtil.Translate("August"),
            LanguageUtil.Translate("September"),
            LanguageUtil.Translate("October"),
            LanguageUtil.Translate("November"),
            LanguageUtil.Translate("December")
        };


        public static int GetMonth(string month) {  return Months.IndexOf(month) + 1; }
    }
}
