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
using System.Windows.Shapes;

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
