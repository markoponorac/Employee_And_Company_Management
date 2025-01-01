using Employee_And_Company_Management.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_And_Company_Management.Views.Windows.Components
{
    public class WarningMessageBox
    {
        public static void Show(string message)
        {
            CustomMessageBox.Show(LanguageUtil.Translate("Warning"), message, MessageBoxButton.OK);
        }
    }
}
