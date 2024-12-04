using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Employee_And_Company_Management.Util
{
    public class ThemeUtil
    {
        public static void ChangeTheme(string cultureName)
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri($"/Theme/{cultureName}Theme.xaml", UriKind.Relative);

            if (Application.Current.Resources.MergedDictionaries.Count > 0)
            {
                Application.Current.Resources.MergedDictionaries.Clear();
            }
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }
    }
}
