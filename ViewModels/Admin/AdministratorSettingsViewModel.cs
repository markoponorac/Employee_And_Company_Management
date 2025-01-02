using Employee_And_Company_Management.Commands;
using Employee_And_Company_Management.Data.Entities;
using Employee_And_Company_Management.Helpers.Constants;
using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.Services;
using Employee_And_Company_Management.Util;
using Employee_And_Company_Management.Views.Windows.Components;
using System.Windows;
using System.Windows.Input;

namespace Employee_And_Company_Management.ViewModels.Admin
{
    public class AdministratorSettingsViewModel : BaseViewModel
    {
        public ICommand ChangeThemeCommand { get; set; }
        public ICommand ChangeLanguageCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand UpdateProfileCommand { get; set; }

        public ProfileServise ProfileServise { get; set; }
        public AdminService AdminService { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewConfirmedPassword { get; set; }

        private string _username;
        private string _firstname;
        private string _lastname;
        private string _jmb;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }
        public string Firstname
        {
            get => _firstname;
            set => SetProperty(ref _firstname, value);
        }
        public string Lastname
        {
            get => _lastname;
            set => SetProperty(ref _lastname, value);
        }
        public string Jmb
        {
            get => _jmb;
            set => SetProperty(ref _jmb, value);
        }
        public LoginDTO LoginDTO { get; set; }

        public AdministratorSettingsViewModel(LoginDTO loginDTO)
        {
            ChangeLanguageCommand = new RelayCommand(ExecuteChangeLanguage, CanExecuteChangeLanguage);
            ChangeThemeCommand = new RelayCommand(ExecuteChangeTheme, CanExecuteChangeTheme);
            ChangePasswordCommand = new RelayCommand(ExecuteChangePassword, CanExecuteChangePassword);
            UpdateProfileCommand = new RelayCommand(ExecuteUpdateProfile, CanExecuteUpdateProfile);
            ProfileServise = new ProfileServise();
            AdminService = new AdminService();
            LoginDTO = loginDTO;
            Username = LoginDTO.UserName;
            Firstname = loginDTO.Firstname;
            Lastname = loginDTO.Lastname;
            Jmb = loginDTO.Jmb;
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
                await ProfileServise.ChangeLanguage(LoginDTO.ProfileId, languageName);
            }
        }

        private async void ExecuteUpdateProfile(object obj)
        {
            if (string.IsNullOrEmpty(Firstname) || string.IsNullOrEmpty(Lastname))
            {
                CustomMessageBox.Show(LanguageUtil.Translate("AllFieldsRequired"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
                return;
            }
            var admin = new Administrator()
            {
                PersonProfileId = LoginDTO.ProfileId,
                PersonProfile = new Person()
                {
                    FirstName = Firstname,
                    LastName = Lastname
                }
            };
            var temp = await AdminService.UpdateAdmin(admin);
            if (temp)
            {
                CustomMessageBox.Show(LanguageUtil.Translate("UpdateSuccess"), LanguageUtil.Translate("Information"), MessageBoxButton.OK);
                if (!string.IsNullOrEmpty(Firstname))
                    LoginDTO.Firstname = Firstname;
                if (!string.IsNullOrEmpty(Lastname))
                    LoginDTO.Lastname = Lastname;
            }
            else
            {
                CustomMessageBox.Show(LanguageUtil.Translate("UpdateNotSuccess"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
            }
           
        }
        private async void ExecuteChangeTheme(object obj)
        {
            string themeName = obj as string;
            if (!string.IsNullOrEmpty(themeName))
            {
                await ProfileServise.ChangeTheme(LoginDTO.ProfileId, themeName);
                ThemeUtil.ChangeTheme(themeName);
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
            else if ( await ProfileServise.ChangePassword(LoginDTO.ProfileId, OldPassword, NewPassword))
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
