using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.ViewModels.Admin;
using System.Windows;
using System.Windows.Controls;

namespace Employee_And_Company_Management.Views.Controls.Admin
{
    /// <summary>
    /// Interaction logic for AdministratorSettingsControl.xaml
    /// </summary>
    public partial class AdministratorSettingsControl : UserControl
    {
        public LoginDTO LoginDTO { get; set; }

        public AdministratorSettingsControl(LoginDTO loginDTO)
        {
            InitializeComponent();
            this.LoginDTO = loginDTO;
            var viewModel = new AdministratorSettingsViewModel(LoginDTO);
            DataContext = viewModel;
        }



        private void UserPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is AdministratorSettingsViewModel viewModel)
            {
                viewModel.OldPassword = (sender as PasswordBox)?.Password;
            }
        }


        private void UserNewAgainPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is AdministratorSettingsViewModel viewModel)
            {
                viewModel.NewConfirmedPassword = (sender as PasswordBox)?.Password;
            }

        }

        private void UserNewPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is AdministratorSettingsViewModel viewModel)
            {
                viewModel.NewPassword = (sender as PasswordBox)?.Password;
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is AdministratorSettingsViewModel viewModel)
            {
                viewModel.reload();
                UserPasswordBox.Password = String.Empty;
                UserNewPasswordBox.Password = String.Empty;
                UserNewAgainPasswordBox.Password = String.Empty;
                
            }
        }
    }
}
