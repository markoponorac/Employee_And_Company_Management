using Employee_And_Company_Management;
using Employee_And_Company_Management.Models;
using System.IO;
using System.Windows;

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

        // Store MaterialDesign dictionaries
        var materialDictionaries = App.Current.Resources.MergedDictionaries
            .Where(d => d.Source != null && d.Source.ToString().Contains("MaterialDesign"))
            .ToList();

        // Clear existing theme resources
        var themeDictionaries = App.Current.Resources.MergedDictionaries
            .Where(d => d.Source != null && d.Source.ToString().Contains("/Themes/"))
            .ToList();

        foreach (var dict in themeDictionaries)
        {
            App.Current.Resources.MergedDictionaries.Remove(dict);
        }

        // Re-add MaterialDesign dictionaries first
        foreach (var dict in materialDictionaries)
        {
            if (!App.Current.Resources.MergedDictionaries.Contains(dict))
            {
                App.Current.Resources.MergedDictionaries.Add(dict);
            }
        }

        // Add new theme dictionary
        var newTheme = new ResourceDictionary { Source = new Uri(result.Path) };
        App.Current.Resources.MergedDictionaries.Add(newTheme);
    }

    public static void ChangeTheme(Uri uri)
    {
        // Store MaterialDesign dictionaries
        var materialDictionaries = App.Current.Resources.MergedDictionaries
            .Where(d => d.Source != null && d.Source.ToString().Contains("MaterialDesign"))
            .ToList();

        // Clear existing theme resources
        var themeDictionaries = App.Current.Resources.MergedDictionaries
            .Where(d => d.Source != null && d.Source.ToString().Contains("/Themes/"))
            .ToList();

        foreach (var dict in themeDictionaries)
        {
            App.Current.Resources.MergedDictionaries.Remove(dict);
        }

        // Re-add MaterialDesign dictionaries first
        foreach (var dict in materialDictionaries)
        {
            if (!App.Current.Resources.MergedDictionaries.Contains(dict))
            {
                App.Current.Resources.MergedDictionaries.Add(dict);
            }
        }

        // Add new theme dictionary
        var newTheme = new ResourceDictionary { Source = uri };
        App.Current.Resources.MergedDictionaries.Add(newTheme);
    }
}