using Employee_And_Company_Management.Helpers.Constants;
using Employee_And_Company_Management.Util;
using Employee_And_Company_Management.ViewModels;
using Employee_And_Company_Management.Views.Windows;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Employee_And_Company_Management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new LoginViewModel(this);
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.Password = (sender as PasswordBox)?.Password;
            }
        }


        private void SerbianButton_Click(object sender, RoutedEventArgs e)
        {
            LanguageUtil.ChangeLanguage("sr-Latn-RS");
        }

        private void EnglishButton_Click(object sender, RoutedEventArgs e)
        {
            LanguageUtil.ChangeLanguage("en-US");
        }

    }
}