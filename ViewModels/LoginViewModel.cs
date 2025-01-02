using Employee_And_Company_Management.Commands;
using Employee_And_Company_Management.Helpers.Constants;
using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.Services;
using Employee_And_Company_Management.Util;
using Employee_And_Company_Management.Views.Windows;
using Employee_And_Company_Management.Views.Windows.Companies;
using Employee_And_Company_Management.Views.Windows.Components;
using Employee_And_Company_Management.Views.Windows.Employees;
using System.Windows;
using System.Windows.Input;


namespace Employee_And_Company_Management.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly LoginService _loginService;
        public string Username { get; set; }
        public string Password { get; set; }

        private Window _currentWindow;

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public ICommand LoginCommand { get; set; }

        public LoginViewModel(Window window)
        {
            _loginService = new LoginService();
            LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
            _currentWindow = window;
        }


        private bool CanExecuteLogin(object obj)
        {
            return true;
        }

        private async void ExecuteLogin(object obj)
        {
            try
            {
                IsLoading = true;
                var responseLoginDTO = await Task.Run(() => _loginService.LoginAsync(Username, Password));

                if (responseLoginDTO.Success)
                {
                    if (responseLoginDTO.IsDeleted)
                    {
                        CustomMessageBox.Show(LanguageUtil.Translate("ProfileDeleted"),
                            LanguageUtil.Translate("Warning"),
                            MessageBoxButton.OK);
                        return;
                    }
                    if (!responseLoginDTO.IsActive)
                    {
                        CustomMessageBox.Show(LanguageUtil.Translate("ProfileSuspended"),
                            LanguageUtil.Translate("Warning"),
                            MessageBoxButton.OK);
                        return;
                    }

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        if (RoleConstants.ADMINISTRATOR.Equals(responseLoginDTO.Role))
                        {
                            AdministratorWindow administratorWindow = new AdministratorWindow(responseLoginDTO);
                            administratorWindow.Show();
                            _currentWindow.Close();
                        }
                        if (RoleConstants.COMPANY.Equals(responseLoginDTO.Role))
                        {
                            CompanyWindow companyWindow = new CompanyWindow(responseLoginDTO);
                            companyWindow.Show();
                            _currentWindow.Close();
                        }
                        if (RoleConstants.EMPLOYEE.Equals(responseLoginDTO.Role))
                        {
                            EmployeeWindow employeeWindow = new EmployeeWindow(responseLoginDTO);
                            employeeWindow.Show();
                            _currentWindow.Close();
                        }
                    });
                }
                else
                {
                    CustomMessageBox.Show(LanguageUtil.Translate("LoginFailed"),
                        LanguageUtil.Translate("Warning"),
                        MessageBoxButton.OK);
                }
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}

