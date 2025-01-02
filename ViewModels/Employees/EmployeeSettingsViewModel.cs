using Employee_And_Company_Management.Commands;
using Employee_And_Company_Management.Data.Entities;
using Employee_And_Company_Management.Helpers.Constants;
using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.Services;
using Employee_And_Company_Management.Util;
using System.Windows.Input;
using System.Windows;
using Employee_And_Company_Management.Views.Windows.Components;

namespace Employee_And_Company_Management.ViewModels.Employees
{
    public class EmployeeSettingsViewModel : BaseViewModel
    {
        public ICommand ChangeThemeCommand { get; set; }
        public ICommand ChangeLanguageCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand UpdateProfileCommand { get; set; }

        private ProfileServise _profileServise;
        private EmployeeService _employeeService;

        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewConfirmedPassword { get; set; }

        private string _username;
        private string _firstname;
        private string _lastname;
        private string _jmb;
        private string _dateOfBirth;
        private string _qualification;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }
        public string DateOfBirth
        {
            get => _dateOfBirth;
            set => SetProperty(ref _dateOfBirth, value);
        }
        public string FirstName
        {
            get => _firstname;
            set => SetProperty(ref _firstname, value);
        }
        public string LastName
        {
            get => _lastname;
            set => SetProperty(ref _lastname, value);
        }
        public string Jmb
        {
            get => _jmb;
            set => SetProperty(ref _jmb, value);
        }
        public string Qualification
        {
            get => _qualification;
            set => SetProperty(ref _qualification, value);
        }
        public LoginDTO LoginDTO { get; set; }

        public EmployeeSettingsViewModel(LoginDTO loginDTO)
        {
            LoginDTO = loginDTO;
            _profileServise = new ProfileServise();
            _employeeService = new EmployeeService();
            ChangeLanguageCommand = new RelayCommand(ExecuteChangeLanguage, CanExecuteChangeLanguage);
            ChangeThemeCommand = new RelayCommand(ExecuteChangeTheme, CanExecuteChangeTheme);
            ChangePasswordCommand = new RelayCommand(ExecuteChangePassword, CanExecuteChangePassword);
            UpdateProfileCommand = new RelayCommand(ExecuteUpdateProfile, CanExecuteUpdateProfile);
            Username = loginDTO.UserName;
            FirstName = loginDTO.Firstname;
            Jmb = loginDTO.Jmb;
            LastName = loginDTO.Lastname;
            DateOfBirth = loginDTO.DateOfEstablish.ToString();
            Qualification = loginDTO.Qualification;
        }


        private bool CanExecuteChangeLanguage(object obj) => true;
        private bool CanExecuteChangeTheme(object obj) => true;
        private bool CanExecuteUpdateProfile(object obj) => true;
        private bool CanExecuteChangePassword(object obj)
        {

            return true;
        }

        private async void ExecuteChangeLanguage(object obj)
        {
            string languageName = obj as string;
            if (!string.IsNullOrEmpty(languageName))
            {
                LanguageUtil.ChangeLanguage(languageName);
                await _profileServise.ChangeLanguage(LoginDTO.ProfileId, languageName);

            }
        }
        private async void ExecuteUpdateProfile(object obj)
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName))
            {
                CustomMessageBox.Show(LanguageUtil.Translate("AllFieldsRequired"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
                return;
            }
            var employee = new Employee()
            {
                PersonProfileId = LoginDTO.ProfileId,
                PersonProfile = new Person()
                {
                    FirstName = FirstName,
                    LastName = LastName
                }
            };
            bool result = await _employeeService.UpdateEmployee(employee);
            if (result)
            {
                CustomMessageBox.Show(LanguageUtil.Translate("UpdateSuccess"), LanguageUtil.Translate("Information"), MessageBoxButton.OK);
                LoginDTO.Firstname = FirstName;
                LoginDTO.Lastname = LastName;
            }
            else
            {
                CustomMessageBox.Show(LanguageUtil.Translate("UpdateNotSuccess"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
                FirstName = LoginDTO.Firstname;
                LastName = LoginDTO.Lastname;
            }

        }


        private async void ExecuteChangeTheme(object obj)
        {
            string themeName = obj as string;
            if (!string.IsNullOrEmpty(themeName))
            {
                ThemeUtil.ChangeTheme(themeName);
                await _profileServise.ChangeTheme(LoginDTO.ProfileId, themeName);
            }
        }

        private async void ExecuteChangePassword(object obj)
        {
            if (string.IsNullOrEmpty(OldPassword) || string.IsNullOrEmpty(NewPassword) || string.IsNullOrEmpty(NewConfirmedPassword))
            {
                CustomMessageBox.Show(LanguageUtil.Translate("AllFieldsRequired"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
            }
            else if (NewPassword.Length <= UtilConstants.MIN_PASSWORD_LENGTH)
            {
                CustomMessageBox.Show(LanguageUtil.Translate("PasswordToShort"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
            }
            else if (NewPassword.Equals(OldPassword))
            {
                CustomMessageBox.Show(LanguageUtil.Translate("PasswordsEquals"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
            }
            else if (!NewPassword.Equals(NewConfirmedPassword))
            {
                CustomMessageBox.Show(LanguageUtil.Translate("NewPasswordsNotEquals"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
            }
            else if (await _profileServise.ChangePassword(LoginDTO.ProfileId, OldPassword, NewPassword))
            {
                CustomMessageBox.Show(LanguageUtil.Translate("PasswordChanged"), LanguageUtil.Translate("Information"), MessageBoxButton.OK);
            }
            else
            {
                CustomMessageBox.Show(LanguageUtil.Translate("WrongPassword"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
            }
        }
    }
}
