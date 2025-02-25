﻿using Employee_And_Company_Management.Commands;

using Employee_And_Company_Management.Helpers.Constants;
using Employee_And_Company_Management.Helpers;
using Employee_And_Company_Management.Services;
using Employee_And_Company_Management.Util;
using Employee_And_Company_Management.Views.Windows;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Employee_And_Company_Management.Data.Entities;
using Employee_And_Company_Management.Views.Windows.Components;

namespace Employee_And_Company_Management.ViewModels.Admin
{
    public class CompaniesAdminViewModel : BaseViewModel
    {

        private ObservableCollection<Company> _activeCompanies;
        public ObservableCollection<Company> ActiveCompanies
        {
            get => _activeCompanies;
            set => SetProperty(ref _activeCompanies, value);
        }

        private ObservableCollection<Company> _blockedCompanies;
        public ObservableCollection<Company> BlockedCompanies
        {
            get => _blockedCompanies;
            set => SetProperty(ref _blockedCompanies, value);
        }


        private ObservableCollection<Company> _deletedCompanies;
        public ObservableCollection<Company> DeletedCompanies
        {
            get => _deletedCompanies;
            set => SetProperty(ref _deletedCompanies, value);
        }


        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                FilterCompanyes();
            }
        }


        public ICommand BlockCommand { get; set; }
        public ICommand ActiveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ViewDetailsCommand { get; set; }
        public ICommand AddCompanyCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        private readonly CompanyService _companyService;

        private string _username;
        private string _name;
        private string _jib;
        private string _address;
        private DateTime? _dateOfEstablish;
        private string _password;
        private string _confirmedPassword;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public string Jib
        {
            get => _jib;
            set => SetProperty(ref _jib, value);
        }
        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }


        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public string ConfirmedPassword
        {
            get => _confirmedPassword;
            set => SetProperty(ref _confirmedPassword, value);
        }



        public DateTime? DateOfEstablish
        {
            get => _dateOfEstablish;
            set => SetProperty(ref _dateOfEstablish, value);
        }


        public CompaniesAdminViewModel()
        {
            _companyService = new CompanyService();
            BlockCommand = new RelayCommand(BlockCompany, CanModifyCompanye);
            ActiveCommand = new RelayCommand(ActiveCompany, CanModifyCompanye);
            DeleteCommand = new RelayCommand(DeleteCompany, CanModifyCompanye);
            ViewDetailsCommand = new RelayCommand(ViewDetails, CanModifyCompanye);
            AddCompanyCommand = new RelayCommand(AddCompany, CanModifyCompanye);
            SaveCommand = new RelayCommand(SaveNewCompany, CanModifyCompanye);
            LoadCompanies();
        }


        private async void LoadCompanies()
        {
            var companies = await _companyService.GetCompanies();
            ActiveCompanies = new ObservableCollection<Company>(companies.Where(e => !e.Profile.IsDeleted && e.Profile.IsActive));
            BlockedCompanies = new ObservableCollection<Company>(companies.Where(e => !e.Profile.IsDeleted && !e.Profile.IsActive));
            DeletedCompanies = new ObservableCollection<Company>(companies.Where(e => e.Profile.IsDeleted));

        }

        private async void FilterCompanyes()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                LoadCompanies();
            }
            else
            {
                var companies = await _companyService.GetCompanies();
                ActiveCompanies = new ObservableCollection<Company>(companies.Where(e => !e.Profile.IsDeleted && e.Profile.IsActive
                && (e.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || e.Profile.Username.Contains(SearchText, StringComparison.OrdinalIgnoreCase))));
                BlockedCompanies = new ObservableCollection<Company>(companies.Where(e => !e.Profile.IsDeleted && !e.Profile.IsActive
                && (e.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || e.Profile.Username.Contains(SearchText, StringComparison.OrdinalIgnoreCase))));
                DeletedCompanies = new ObservableCollection<Company>(companies.Where(e => e.Profile.IsDeleted
                && (e.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || e.Profile.Username.Contains(SearchText, StringComparison.OrdinalIgnoreCase))));



            }
        }

        private async void SaveNewCompany(object parameter)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Jib) ||
                string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmedPassword) || DateOfEstablish == null)
            {
                CustomMessageBox.Show(LanguageUtil.Translate("AllFieldsRequired"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
                return;
            }
            if (!Password.Equals(ConfirmedPassword))
            {
                CustomMessageBox.Show(LanguageUtil.Translate("NewPasswordsNotEquals"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
                return;
            }
            if (Password.Length < UtilConstants.MIN_PASSWORD_LENGTH)
            {
                CustomMessageBox.Show(LanguageUtil.Translate("PasswordToShort"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
                return;
            }
            if (Jib.Length != 12 || !Jib.All(char.IsDigit))
            {
                CustomMessageBox.Show(LanguageUtil.Translate("JibIncorect"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
                return;
            }
            Company company = new Company()
            {
                DateOfEstablishment = (DateOnly)DateConverter.ConvertToDateOnly(DateOfEstablish),
                Jib = Jib,
                Address = Address,
                Name = Name,
                Profile = new Profile()
                {
                    Username = Username,
                    Password = Password,
                    Theme = "BlueTheme",
                    Language = "en-US",
                    IsActive = true,
                    IsDeleted = false
                }
            };

            string result = await _companyService.AddCompany(company);
            if (result.Equals(ServiceOperationStatus.SUCCESS))
            {
                CustomMessageBox.Show(LanguageUtil.Translate("CompanyAdded"), LanguageUtil.Translate("Information"), MessageBoxButton.OK);
                await ReloadCompaniesAsync();
            }
            else if (result.Equals(ServiceOperationStatus.ALREADY_EXISTS))
            {
                CustomMessageBox.Show(LanguageUtil.Translate("CompanyAlreadyExists"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
            }
            else if (result.Equals(ServiceOperationStatus.ERROR))
            {
                CustomMessageBox.Show(LanguageUtil.Translate("AddError"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
            }
            else
            {
                CustomMessageBox.Show(LanguageUtil.Translate("CompanyNotAdded"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
            }

            windowAddCompany.Close();
            windowAddCompany = null;
            Username = string.Empty;
            Password = string.Empty;
            Name = string.Empty;
            Jib= string.Empty;
            ConfirmedPassword = string.Empty;
            DateOfEstablish = null;
            Address = string.Empty;
        }
        private bool CanModifyCompanye(object parameter) => true;


        private async void BlockCompany(object parameter)
        {
            if (parameter is Company company)
            {
                var result = CustomMessageBox.Show(LanguageUtil.Translate("BlockCompanyCofirmMessage"), LanguageUtil.Translate("BlockCofirm"), MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    var temp = await _companyService.ChangeActiveStatus(company.ProfileId);
                    if (temp)
                        await ReloadCompaniesAsync();
                }
            }
        }
        private async void ActiveCompany(object parameter)
        {
            if (parameter is Company company)
            {
                var result = CustomMessageBox.Show(LanguageUtil.Translate("ActiveCompanyCofirmMessage"), LanguageUtil.Translate("ActiveCofirm"), MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    var temp = await _companyService.ChangeActiveStatus(company.ProfileId);
                    if (temp)
                        await ReloadCompaniesAsync();
                }
            }
        }

        private async void DeleteCompany(object parameter)
        {
            if (parameter is Company company)
            {
                var result = CustomMessageBox.Show(LanguageUtil.Translate("DeleteCompanyCofirmMessage"), LanguageUtil.Translate("DeleteCofirm"), MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    var temp = await _companyService.DeleteCompany(company.ProfileId);
                    if (temp)
                        await ReloadCompaniesAsync();
                }
            }
        }

        private void ViewDetails(object parameter)
        {
            if (parameter is Company company)
            {
                Window window = new CompanyDetailsWindow(company);
                window.ShowDialog();
            }
        }
        Window windowAddCompany;
        private void AddCompany(object parameter)
        {
            windowAddCompany = new AddNewCompanyeeWindow(this);
            windowAddCompany.ShowDialog();
        }
        private async Task ReloadCompaniesAsync()
        {
            var companies = await _companyService.GetCompanies();

            ActiveCompanies.Clear();
            foreach (var company in companies.Where(e => !e.Profile.IsDeleted && e.Profile.IsActive))
            {
                ActiveCompanies.Add(company);
            }

            BlockedCompanies.Clear();
            foreach (var company in companies.Where(e => !e.Profile.IsDeleted && !e.Profile.IsActive))
            {
                BlockedCompanies.Add(company);
            }

            DeletedCompanies.Clear();
            foreach (var company in companies.Where(e => e.Profile.IsDeleted))
            {
                DeletedCompanies.Add(company);
            }
        }
    }
}
