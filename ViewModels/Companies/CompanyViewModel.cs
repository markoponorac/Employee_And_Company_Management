﻿using Employee_And_Company_Management.Commands;
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
        public ICommand NavigateToWrokPlacesCommand { get; set; }

        private bool _isEmployeesSelected;
        public bool IsEmployeesSelected
        {
            get => _isEmployeesSelected;
            set => SetProperty(ref _isEmployeesSelected, value);
        }

        private bool _isDepartmentsSelected;
        public bool IsDepartmentsSelected
        {
            get => _isDepartmentsSelected;
            set => SetProperty(ref _isDepartmentsSelected, value);
        }

        private bool _isWorkPlacesSelected;
        public bool IsWorkPlacesSelected
        {
            get => _isWorkPlacesSelected;
            set => SetProperty(ref _isWorkPlacesSelected, value);
        }
        private bool _isSettingSelected;
        public bool IsSettingSelected
        {
            get => _isSettingSelected;
            set => SetProperty(ref _isSettingSelected, value);
        }

        public LoginDTO LoginDTO { get; set; }

        public CompanyViewModel(LoginDTO loginDTO)
        {
            NavigateToSettingsCommand = new RelayCommand(ExecuteNavigateToSettings, CanExecuteNavigateToSettings);
            NavigateToEmployeesCommand = new RelayCommand(ExecuteNavigateToEmployees, CanExecuteNavigateToEmployees);
            NavigateToDepartmentsCommand = new RelayCommand(ExecuteNavigateToDepartments, CanExecuteNavigateToDepartments);
            NavigateToWrokPlacesCommand = new RelayCommand(ExecuteNavigateToWorkPlaces, CanExecuteNavigateToWorkPlaces);
            LoginDTO = loginDTO;
        }

        public void InitialNavigation()
        {
            ExecuteNavigateToEmployees(null);
        }
        private bool CanExecuteNavigateToSettings(object obj) => true;
        private bool CanExecuteNavigateToEmployees(object obj) => true;
        private bool CanExecuteNavigateToDepartments(object obj) => true;
        private bool CanExecuteNavigateToWorkPlaces(object obj) => true;
        private bool CanExecuteNavigateToSalaries(object obj) => true;

        private void ExecuteNavigateToSettings(object obj)
        {
            IsEmployeesSelected = false;
            IsDepartmentsSelected = false;
            IsWorkPlacesSelected = false;
            IsSettingSelected = true;
            CurrentPage = new CompanySettingsControl(LoginDTO);
        }

        private void ExecuteNavigateToEmployees(object obj)
        {
            IsEmployeesSelected = true;
            IsDepartmentsSelected = false;
            IsWorkPlacesSelected = false;
            IsSettingSelected = false;
            CurrentPage = new EmployeeCompanyControl(LoginDTO);
        }
        private void ExecuteNavigateToDepartments(object obj)
        {
            IsEmployeesSelected = false;
            IsDepartmentsSelected = true;
            IsWorkPlacesSelected = false;
            IsSettingSelected = false;
            CurrentPage = new DepartmentsCompanyControl(LoginDTO);
        }
        private void ExecuteNavigateToWorkPlaces(object obj)
        {
            IsEmployeesSelected = false;
            IsDepartmentsSelected = false;
            IsWorkPlacesSelected = true;
            IsSettingSelected = false;
            CurrentPage = new WorkPlacesCompanyControl(LoginDTO);
        }

    }
}
