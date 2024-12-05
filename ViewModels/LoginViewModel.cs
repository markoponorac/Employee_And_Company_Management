using Employee_And_Company_Management.Commands;
using Employee_And_Company_Management.Helpers.Constants;
using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.Services;
using Employee_And_Company_Management.Util;
using Employee_And_Company_Management.Views.Windows;
using System.Windows;
using System.Windows.Input;


namespace Employee_And_Company_Management.ViewModels
{
    public class LoginViewModel
    {
        private readonly LoginService _loginService;
        public string Username { get; set; }
        public string Password { get; set; }

        private Window _currentWindow;

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

        private void ExecuteLogin(object obj)
        {

            var responseLoginDTO = _loginService.LoginAsync(Username, Password);
            if (responseLoginDTO.Success)
            {
                if (responseLoginDTO.IsDeleted)
                {
                    MessageBox.Show(LanguageUtil.Translate("ProfileDeleted"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (!responseLoginDTO.IsActive)
                {
                    MessageBox.Show(LanguageUtil.Translate("ProfileSuspended"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
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
            }
            else
            {
                MessageBox.Show(LanguageUtil.Translate("LoginFailed"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }
    }
}

