using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.ViewModels.Admin;
using Employee_And_Company_Management.ViewModels.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Employee_And_Company_Management.Views.Controls.Companies
{
    /// <summary>
    /// Interaction logic for CompanySettingsControl.xaml
    /// </summary>
    public partial class CompanySettingsControl : UserControl
    {
        public CompanySettingsControl(LoginDTO loginDTO)
        {
            InitializeComponent();
            var viewModel=new CompanySettingsViewModel(loginDTO);
            DataContext = viewModel;
        }

        private void UserPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is CompanySettingsViewModel viewModel)
            {
                viewModel.OldPassword = (sender as PasswordBox)?.Password;
            }
        }

        private void UserNewAgainPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is CompanySettingsViewModel viewModel)
            {
                viewModel.NewConfirmedPassword = (sender as PasswordBox)?.Password;
            }

        }
        private void UserNewPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is CompanySettingsViewModel viewModel)
            {
                viewModel.NewPassword = (sender as PasswordBox)?.Password;
            }
        }


    }
}
