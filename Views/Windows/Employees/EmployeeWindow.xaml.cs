using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.Util;
using Employee_And_Company_Management.ViewModels.Employees;
using System;
using System.Windows;

namespace Employee_And_Company_Management.Views.Windows.Employees
{
    public partial class EmployeeWindow : Window
    {
        private readonly LoginDTO _loginDTO;
        public EmployeeWindow(LoginDTO loginDTO )
        {
            InitializeComponent();
            _loginDTO = loginDTO;
            LanguageUtil.ChangeLanguage(_loginDTO.Language);
            ThemeUtil.ChangeTheme(_loginDTO.Theme);
            var viewModel = new EmployeesViewModel(loginDTO);
            DataContext = viewModel;
            Loaded += (s, e) => viewModel.InitialNavigation();

        }


    }
}