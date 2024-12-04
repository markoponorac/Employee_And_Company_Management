using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Employee_And_Company_Management.Util
{
    public class LanguageUtil
    {
        public static string? CurrentLanguage {  get; set; }

        public static string? Translate(string? key)
        {
            return Application.Current.Resources[key] as String;
        }

        public static void ChangeLanguage(string cultureName)
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri($"/Resources/StringResources.{cultureName}.xaml", UriKind.Relative);

            if (Application.Current.Resources.MergedDictionaries.Count > 0)
            {
                Application.Current.Resources.MergedDictionaries.Clear();
            }
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }
    }
}
