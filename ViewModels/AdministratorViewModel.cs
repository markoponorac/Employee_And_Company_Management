using Employee_And_Company_Management.Commands;
using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.Views.Controls.Admin;
using System.Windows.Controls;
using System.Windows.Input;

namespace Employee_And_Company_Management.ViewModels
{
    public class AdministratorViewModel : BaseViewModel
    {
        private Control _currentPage;
        public Control CurrentPage
        {
            get => _currentPage;
            set => SetProperty(ref _currentPage, value);
        }

        public ICommand NavigateToSettingsCommand { get; set; }
        public ICommand NavigateToEmployeesCommand { get; set; }

        public LoginDTO LoginDTO { get; set; }

        public AdministratorViewModel(LoginDTO loginDTO)
        {
            NavigateToSettingsCommand = new RelayCommand(ExecuteNavigateToSettings, CanExecuteNavigateToSettings);
            NavigateToEmployeesCommand = new RelayCommand(ExecuteNavigateToEmployees, CanExecuteNavigateToEmployees);
            LoginDTO = loginDTO;
        }

        private bool CanExecuteNavigateToSettings(object obj) => true;
        private bool CanExecuteNavigateToEmployees(object obj) => true;

        private void ExecuteNavigateToSettings(object obj)
        {
            CurrentPage = new AdministratorSettingsControl(LoginDTO);
        }
        private void ExecuteNavigateToEmployees(object obj)
        {
            CurrentPage = new EmployeeControl();
        }
    }

}
