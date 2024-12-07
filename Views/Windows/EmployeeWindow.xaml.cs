using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.Util;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Employee_And_Company_Management.Views.Windows
{
    public partial class EmployeeWindow : Window
    {
        private readonly LoginDTO _loginDTO;
        public EmployeeWindow(LoginDTO loginDTO )
        {
            InitializeComponent();
            _loginDTO = loginDTO;
            LanguageUtil.ChangeLanguage(_loginDTO.Language); 
            //var viewModel = new AdministratorViewModel();
            //viewModel.CurrentPage = new EmployeeControl();
            //DataContext = viewModel;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}