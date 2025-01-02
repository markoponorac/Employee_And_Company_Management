using Employee_And_Company_Management.ViewModels.Admin;
using System.Windows;
using System.Windows.Controls;

namespace Employee_And_Company_Management.Views.Windows
{
    /// <summary>
    /// Interaction logic for AddNewEmployeeWindow.xaml
    /// </summary>
    public partial class AddNewEmployeeWindow : Window
    {
        public AddNewEmployeeWindow(EmployeesAdminViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void UserPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is EmployeesAdminViewModel viewModel)
            {
                viewModel.Password = (sender as PasswordBox)?.Password;
            }
        }

        private void UserAgainPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is EmployeesAdminViewModel viewModel)
            {
                viewModel.ConfirmedPassword = (sender as PasswordBox)?.Password;
            }
        }
    }
}
