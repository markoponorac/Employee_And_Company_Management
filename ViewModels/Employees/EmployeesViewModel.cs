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
        private bool _isEmployeesSelected;
        public bool IsEmployeesSelected
        {
            get => _isEmployeesSelected;
            set => SetProperty(ref _isEmployeesSelected, value);
        }

        private bool _isSettingSelected;
        public bool IsSettingSelected
        {
            get => _isSettingSelected;
            set => SetProperty(ref _isSettingSelected, value);
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
            IsEmployeesSelected = false;
            IsSettingSelected = true;
            CurrentPage = new EmployeeSettingsControl(_loginDTO);
        }

        private void ExecuteNavigateToEmployments(object obj)
        {
            IsEmployeesSelected = true;
            IsSettingSelected = false;
            CurrentPage = new EmploymentsControl(_loginDTO);
        }
    }
}
