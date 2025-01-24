using Employee_And_Company_Management.Commands;
using Employee_And_Company_Management.Data.Entities;
using Employee_And_Company_Management.Helpers.Constants;
using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.Services;
using Employee_And_Company_Management.Util;
using Employee_And_Company_Management.Views.Windows.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Employee_And_Company_Management.ViewModels.Companies
{
    public class CompanySettingsViewModel : BaseViewModel
    {
        public ICommand ChangeThemeCommand { get; set; }
        public ICommand ChangeLanguageCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand UpdateProfileCommand { get; set; }

        private ProfileServise _profileServise;
        private CompanyService _companyService;

        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewConfirmedPassword { get; set; }

        private string _username;
        private string _name;
        private string _address;
        private string _jib;
        private string _dateOfEstablish;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }
        public string DateOfEstablish
        {
            get => _dateOfEstablish;
            set => SetProperty(ref _dateOfEstablish, value);
        }
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }
        public string Jib
        {
            get => _jib;
            set => SetProperty(ref _jib, value);
        }
        public LoginDTO LoginDTO { get; set; }
        public void reload()
        {
            if (flag)
            {
                Address = LoginDTO.Address;
                OldPassword = String.Empty;
                NewPassword = String.Empty;
                NewConfirmedPassword = String.Empty;
            }
        }

        private bool flag = false;

        public CompanySettingsViewModel(LoginDTO loginDTO)
        {
            LoginDTO = loginDTO;
            _profileServise = new ProfileServise();
            _companyService = new CompanyService();
            ChangeLanguageCommand = new RelayCommand(ExecuteChangeLanguage, CanExecuteChangeLanguage);
            ChangeThemeCommand = new RelayCommand(ExecuteChangeTheme, CanExecuteChangeTheme);
            ChangePasswordCommand = new RelayCommand(ExecuteChangePassword, CanExecuteChangePassword);
            UpdateProfileCommand = new RelayCommand(ExecuteUpdateProfile, CanExecuteUpdateProfile);
            Username = loginDTO.UserName;
            Name = loginDTO.Name;
            Jib = loginDTO.Jib;
            Address = loginDTO.Address;
            DateOfEstablish = loginDTO.DateOfEstablish.ToString();
            flag = true;
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
            if (string.IsNullOrEmpty(Address))
            {
                CustomMessageBox.Show(LanguageUtil.Translate("AllFieldsRequired"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
                return;
            }
            if (Address.Length >= 255)
            {
                CustomMessageBox.Show(LanguageUtil.Translate("MaxLen255"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
                return;
            }
            var company = new Company()
            {
                ProfileId = LoginDTO.ProfileId,
                Address = Address
            };
            var result = await _companyService.Update(company);
            if (result)
            {
                CustomMessageBox.Show(LanguageUtil.Translate("UpdateSuccess"), LanguageUtil.Translate("Information"), MessageBoxButton.OK);
                if (!string.IsNullOrEmpty(Address))
                    LoginDTO.Address = Address;
            }
            else
            {
                CustomMessageBox.Show(LanguageUtil.Translate("UpdateError"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
            }
            reload();
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
            reload();
        }

    }
}
