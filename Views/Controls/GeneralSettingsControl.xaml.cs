using System.Windows;
using System.Windows.Controls;

namespace Employee_And_Company_Management.Views.Controls
{
    public partial class GeneralSettingsControl : UserControl
    {
        public GeneralSettingsControl()
        {
            InitializeComponent();
        }

        private void ChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string theme = button.Tag.ToString();
                // Logika za promenu teme
                MessageBox.Show($"Theme changed to: {theme}");
            }
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LanguageComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string language = selectedItem.Tag.ToString();
                // Logika za promenu jezika
                MessageBox.Show($"Language changed to: {language}");
            }
        }
    }
}
