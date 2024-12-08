using Employee_And_Company_Management.Commands;
using Employee_And_Company_Management.Data.Entities;
using Employee_And_Company_Management.Helpers.Constants;
using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.Services;
using Employee_And_Company_Management.Util;
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

        }


        private bool CanExecuteChangeLanguage(object obj) => true;
        private bool CanExecuteChangeTheme(object obj) => true;
        private bool CanExecuteUpdateProfile(object obj) => true;
        private bool CanExecuteChangePassword(object obj)
        {
            //if(String.IsNullOrEmpty(OldPassword) || String.IsNullOrEmpty(NewPassword) || String.IsNullOrEmpty(NewConfirmedPassword))
            //{
            //    return false;
            //}
            return true;
        }

        private void ExecuteChangeLanguage(object obj)
        {
            string languageName = obj as string;
            if (!string.IsNullOrEmpty(languageName))
            {
                LanguageUtil.ChangeLanguage(languageName);
                _profileServise.ChangeLanguage(LoginDTO.ProfileId, languageName);
               
            }
        }
        private async void ExecuteUpdateProfile(object obj)
        {
            if (string.IsNullOrEmpty(Address))
            {
                MessageBox.Show(LanguageUtil.Translate("AllFieldsRequired"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var company = new Company()
            {
                ProfileId = LoginDTO.ProfileId,
                Address = Address
            };
            await _companyService.Update(company);
            MessageBox.Show(LanguageUtil.Translate("UpdateSuccess"), LanguageUtil.Translate("Information"), MessageBoxButton.OK, MessageBoxImage.Information);
            if (!string.IsNullOrEmpty(Address))
                LoginDTO.Address = Address;
           
        }


        private void ExecuteChangeTheme(object obj)
        {
            string themeName = obj as string;
            if (!string.IsNullOrEmpty(themeName))
            {
                ThemeUtil.ChangeTheme(themeName);
                _profileServise.ChangeTheme(LoginDTO.ProfileId, themeName);
            }
        }

        private void ExecuteChangePassword(object obj)
        {
            if (string.IsNullOrEmpty(OldPassword) || string.IsNullOrEmpty(NewPassword) || string.IsNullOrEmpty(NewConfirmedPassword))
            {
                MessageBox.Show(LanguageUtil.Translate("AllFieldsRequired"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (NewPassword.Length <= UtilConstants.MIN_PASSWORD_LENGTH)
            {
                MessageBox.Show(LanguageUtil.Translate("PasswordToShort"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (NewPassword.Equals(OldPassword))
            {
                MessageBox.Show(LanguageUtil.Translate("PasswordsEquals"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (!NewPassword.Equals(NewConfirmedPassword))
            {
                MessageBox.Show(LanguageUtil.Translate("NewPasswordsNotEquals"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (_profileServise.ChangePassword(LoginDTO.ProfileId, OldPassword, NewPassword))
            {
                MessageBox.Show(LanguageUtil.Translate("PasswordChanged"), LanguageUtil.Translate("Information"), MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(LanguageUtil.Translate("WrongPassword"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
