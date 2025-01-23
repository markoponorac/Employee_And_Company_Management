using Employee_And_Company_Management.Commands;
using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.ViewModels.Employees;
using Employee_And_Company_Management.Views.Controls.Admin;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Employee_And_Company_Management.ViewModels.Admin
{
    public class AdministratorViewModel : BaseViewModel
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

        private bool _isCompaniesSelected;
        public bool IsCompaniesSelected
        {
            get => _isCompaniesSelected;
            set => SetProperty(ref _isCompaniesSelected, value);
        }

        private bool _isQualificationSelected;
        public bool IsQualificationSelected
        {
            get => _isQualificationSelected;
            set => SetProperty(ref _isQualificationSelected, value);
        }
        private bool _isSettingSelected;
        public bool IsSettingSelected
        {
            get => _isSettingSelected;
            set => SetProperty(ref _isSettingSelected, value);
        }



        public ICommand NavigateToSettingsCommand { get; set; }
        public ICommand NavigateToEmployeesCommand { get; set; }
        public ICommand NavigateToCompaniesCommand { get; set; }
        public ICommand NavigateToQualificationCommand { get; set; }

        public LoginDTO LoginDTO { get; set; }

        public AdministratorViewModel(LoginDTO loginDTO)
        {
            NavigateToSettingsCommand = new RelayCommand(ExecuteNavigateToSettings, CanExecuteNavigateToSettings);
            NavigateToEmployeesCommand = new RelayCommand(ExecuteNavigateToEmployees, CanExecuteNavigateToEmployees);
            NavigateToCompaniesCommand = new RelayCommand(ExecuteNavigateToCompanies, CanExecuteNavigateToCompanies);
            NavigateToQualificationCommand = new RelayCommand(ExecuteNavigateToQualification, CanExecuteNavigateToCompanies);
            LoginDTO = loginDTO;
        }

        public void InitialNavigation()
        {
            ExecuteNavigateToEmployees(null);
        }

        private bool CanExecuteNavigateToSettings(object obj) => true;
        private bool CanExecuteNavigateToEmployees(object obj) => true;
        private bool CanExecuteNavigateToCompanies(object obj) => true;

        private void ExecuteNavigateToSettings(object obj)
        {
            IsEmployeesSelected = false;
            IsCompaniesSelected = false;
            IsQualificationSelected = false;
            IsSettingSelected = true;
            CurrentPage = new AdministratorSettingsControl(LoginDTO);
        }
        private void ExecuteNavigateToEmployees(object obj)
        {
            IsEmployeesSelected = true;
            IsCompaniesSelected = false;
            IsQualificationSelected = false;
            IsSettingSelected = false;
            CurrentPage = new EmployeeControl();
        }
        private void ExecuteNavigateToCompanies(object obj)
        {
            IsEmployeesSelected = false;
            IsCompaniesSelected = true;
            IsQualificationSelected = false;
            IsSettingSelected = false;
            CurrentPage = new CompaniesControl();
        }
        private void ExecuteNavigateToQualification(object obj)
        {
            IsEmployeesSelected = false;
            IsCompaniesSelected = false;
            IsQualificationSelected = true;
            IsSettingSelected= false;
            CurrentPage = new QualificationControl();
        }
    }

}
