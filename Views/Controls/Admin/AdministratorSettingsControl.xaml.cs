using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
    }
}
