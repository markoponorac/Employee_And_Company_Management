using Employee_And_Company_Management.Commands;
using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.Views.Controls.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Employee_And_Company_Management.ViewModels.Employees
{
    public class EmployeesViewModel : BaseViewModel
    {
        private Control _currentPage;
        public Control CurrentPage
        {
            get => _currentPage;
            set => SetProperty(ref _currentPage, value);
        }

        public ICommand NavigateToSettingsCommand { get; set; }
        public ICommand NavigateToEmploymentsCommand { get; set; }

        private LoginDTO _loginDTO;

        public EmployeesViewModel(LoginDTO loginDTO)
        {
            _loginDTO = loginDTO;
            NavigateToSettingsCommand = new RelayCommand(ExecuteNavigateToSettings, CanExecuteNavigateToSettings);
            NavigateToEmploymentsCommand = new RelayCommand(ExecuteNavigateToEmployments, CanExecuteNavigateToEmployments);
        }


        public void InitialNavigation()
        {
            ExecuteNavigateToEmployments(null);
        }

        private bool CanExecuteNavigateToSettings(object obj) => true;
        private bool CanExecuteNavigateToEmployments(object obj) => true;

        private void ExecuteNavigateToSettings(object obj)
        {
            CurrentPage = new EmployeeSettingsControl(_loginDTO);
        }

        private void ExecuteNavigateToEmployments(object obj)
        {
            CurrentPage = new EmploymentsControl(_loginDTO);
        }
    }
}
