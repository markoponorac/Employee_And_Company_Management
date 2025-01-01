
using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.ViewModels.Employees;
using System.Windows;
using System.Windows.Controls;

namespace Employee_And_Company_Management.Views.Controls.Employees
{
    /// <summary>
    /// Interaction logic for EmployeeSettingsControl.xaml
    /// </summary>
    public partial class EmployeeSettingsControl : UserControl
    {
        public EmployeeSettingsControl(LoginDTO loginDTO)
        {
            InitializeComponent();
            var viewModel = new EmployeeSettingsViewModel(loginDTO);
            DataContext = viewModel;
        }

        private void UserPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is EmployeeSettingsViewModel viewModel)
            {
                viewModel.OldPassword = (sender as PasswordBox)?.Password;
            }
        }

        private void UserNewAgainPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is EmployeeSettingsViewModel viewModel)
            {
                viewModel.NewConfirmedPassword = (sender as PasswordBox)?.Password;
            }

        }
        private void UserNewPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is EmployeeSettingsViewModel viewModel)
            {
                viewModel.NewPassword = (sender as PasswordBox)?.Password;
            }
        }
    }
}
