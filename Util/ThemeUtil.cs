using Employee_And_Company_Management.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Employee_And_Company_Management.Util
{
    public class ThemeUtil
    {
        private static readonly String PATH = "Themes";

        public static List<Theme> GetThemes()
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectPath = Path.GetFullPath(Path.Combine(executablePath, @"..\..\.."));
            string themesFolderPath = Path.Combine(projectPath, "Themes");
            var files = Directory.GetFiles(themesFolderPath);
            var list = new List<Theme>();
            foreach (var file in files)
            {
                var name = Path.GetFileNameWithoutExtension(file);
                Theme theme = new Theme { Name = name, Path = file };
                list.Add(theme);
            }
            return list;
        }

        public static void ChangeTheme(String uri)
        {
            var theme = GetThemes();
            var result = theme.FirstOrDefault(theme => theme.Name == uri);
            ResourceDictionary resourceDictionary = new ResourceDictionary { Source = new Uri(result.Path) };
            foreach (DictionaryEntry entry in resourceDictionary)
                App.Current.Resources[entry.Key] = entry.Value;
        }

        public static void ChangeTheme(Uri uri)
        {
            ResourceDictionary resourceDictionary = new ResourceDictionary { Source = uri };
            foreach (DictionaryEntry entry in resourceDictionary)
                App.Current.Resources[entry.Key] = entry.Value;
        }
    }
}
