using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.Util;
using Employee_And_Company_Management.ViewModels;
using Employee_And_Company_Management.Views.Controls.Admin;
using Employee_And_Company_Management.Views.Pages;
using Employee_And_Company_Management.Views.Pages.Admin;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Employee_And_Company_Management.Views.Windows
{
    public partial class CompanyWindow : Window
    {
        private readonly LoginDTO _loginDTO;
        public CompanyWindow(LoginDTO loginDTO )
        {
            InitializeComponent();
            _loginDTO = loginDTO;
            LanguageUtil.ChangeLanguage(_loginDTO.Language); 
            ThemeUtil.ChangeTheme(_loginDTO.Theme);
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