﻿using Employee_And_Company_Management.Models;
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
    public class LanguageUtil
    {
        public static List<Language> GetLanguages()
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectPath = Path.GetFullPath(Path.Combine(executablePath, @"..\..\.."));
            string themesFolderPath = Path.Combine(projectPath, "Resources");
            var files = Directory.GetFiles(themesFolderPath);
            var list = new List<Language>();
            foreach (var file in files)
            {
                var name = Path.GetFileNameWithoutExtension(file);
                Language theme = new Language { Name = name, Path = file };
                list.Add(theme);
            }
            return list;
        }

        public static String Translate(String key)
        {
            return App.Current.Resources[key] as String;
        }

        public static void ChangeLanguage(Language language)
        {
            ResourceDictionary resourceDictionary = new ResourceDictionary { Source = new Uri(language.Path) };
            foreach (DictionaryEntry entry in resourceDictionary)
                App.Current.Resources[entry.Key] = entry.Value;
        }

        public static void ChangeLanguage(String uri)
        {
            var languages = GetLanguages();
            var result = languages.FirstOrDefault(lng => lng.Name == uri);
            ResourceDictionary resourceDictionary = new ResourceDictionary { Source = new Uri(result.Path) };
            foreach (DictionaryEntry entry in resourceDictionary)
                App.Current.Resources[entry.Key] = entry.Value;
        }
    }
}
