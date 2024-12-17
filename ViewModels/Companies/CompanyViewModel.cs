using Employee_And_Company_Management.Commands;
using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.Views.Controls.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Employee_And_Company_Management.ViewModels.Companies
{
    public class CompanyViewModel : BaseViewModel
    {

        private Control _currentPage;
        public Control CurrentPage
        {
            get => _currentPage;
            set => SetProperty(ref _currentPage, value);
        }

        public ICommand NavigateToSettingsCommand { get; set; }
        public ICommand NavigateToEmployeesCommand { get; set; }
        public ICommand NavigateToDepartmentsCommand { get; set; }

        public LoginDTO LoginDTO { get; set; }

        public CompanyViewModel(LoginDTO loginDTO)
        {
            NavigateToSettingsCommand = new RelayCommand(ExecuteNavigateToSettings, CanExecuteNavigateToSettings);
            NavigateToEmployeesCommand = new RelayCommand(ExecuteNavigateToEmployees, CanExecuteNavigateToEmployees);
            NavigateToDepartmentsCommand = new RelayCommand(ExecuteNavigateToDepartments, CanExecuteNavigateToDepartments);
            LoginDTO = loginDTO;
        }
        private bool CanExecuteNavigateToSettings(object obj) => true;
        private bool CanExecuteNavigateToEmployees(object obj) => true;
        private bool CanExecuteNavigateToDepartments(object obj) => true;

        private void ExecuteNavigateToSettings(object obj)
        {
            CurrentPage = new CompanySettingsControl(LoginDTO);
        }

        private void ExecuteNavigateToEmployees(object obj)
        {
            CurrentPage = new EmployeeCompanyControl(LoginDTO);
        }
        private void ExecuteNavigateToDepartments(object obj)
        {
            CurrentPage = new EmployeeCompanyControl(LoginDTO);
        }

    }
}
