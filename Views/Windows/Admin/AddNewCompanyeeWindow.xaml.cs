using Employee_And_Company_Management.ViewModels.Admin;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Employee_And_Company_Management.Views.Windows
{
    /// <summary>
    /// Interaction logic for AddNewCompanyeeWindow.xaml
    /// </summary>
    public partial class AddNewCompanyeeWindow : Window
    {
        public AddNewCompanyeeWindow(CompaniesAdminViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }


        private void UserPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is CompaniesAdminViewModel viewModel)
            {
                viewModel.Password = (sender as PasswordBox)?.Password;
            }
        }

        private void UserAgainPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is CompaniesAdminViewModel viewModel)
            {
                viewModel.ConfirmedPassword = (sender as PasswordBox)?.Password;
            }
        }

    }
}
