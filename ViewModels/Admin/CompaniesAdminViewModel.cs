using Employee_And_Company_Management.Commands;

using Employee_And_Company_Management.Helpers.Constants;
using Employee_And_Company_Management.Helpers;
using Employee_And_Company_Management.Services;
using Employee_And_Company_Management.Util;
using Employee_And_Company_Management.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Employee_And_Company_Management.Data.Entities;

namespace Employee_And_Company_Management.ViewModels.Admin
{
    public class CompaniesAdminViewModel : BaseViewModel
    {

        public ObservableCollection<Company> ActiveCompanies { get; set; }
        public ObservableCollection<Company> BlockedCompanies { get; set; }
        public ObservableCollection<Company> DeletedCompanies { get; set; }

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
            Thread.Sleep(100);
        }


        private async void LoadCompanies()
        {
            var companies = await _companyService.GetCompanies();
            ActiveCompanies = new ObservableCollection<Company>(companies.Where(e => !e.Profile.IsDeleted && e.Profile.IsActive));
            BlockedCompanies = new ObservableCollection<Company>(companies.Where(e => !e.Profile.IsDeleted && !e.Profile.IsActive));
            DeletedCompanies = new ObservableCollection<Company>(companies.Where(e => e.Profile.IsDeleted));
           
        }



        private async void SaveNewCompany(object parameter)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Jib) ||
                string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmedPassword) || DateOfEstablish == null)
            {
                MessageBox.Show(LanguageUtil.Translate("AllFieldsRequired"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!Password.Equals(ConfirmedPassword))
            {
                MessageBox.Show(LanguageUtil.Translate("NewPasswordsNotEquals"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (Password.Length < UtilConstants.MIN_PASSWORD_LENGTH)
            {
                MessageBox.Show(LanguageUtil.Translate("PasswordToShort"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (Jib.Length != 12 || !Jib.All(char.IsDigit))
            {
                MessageBox.Show(LanguageUtil.Translate("JibIncorect"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Company company = new Company()
            {
                DateOfEstablishment = (DateOnly)DateConverter.ConvertToDateOnly(DateOfEstablish),
                Jib= Jib,
                Address = Address,
                Name= Name,
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

            bool result = await _companyService.AddCompany(company);
            if (result)
            {
                MessageBox.Show(LanguageUtil.Translate("CompanyAdded"), LanguageUtil.Translate("Information"), MessageBoxButton.OK, MessageBoxImage.Information);
                await ReloadCompaniesAsync();
            }
            else
            {
                MessageBox.Show(LanguageUtil.Translate("CompanyNotAdded"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            windowAddCompany.Close();
            windowAddCompany = null;
        }
        private bool CanModifyCompanye(object parameter) => true;


        private async void BlockCompany(object parameter)
        {
            if (parameter is Company company)
            {
                var result = MessageBox.Show(LanguageUtil.Translate("BlockCompanyCofirmMessage"), LanguageUtil.Translate("BlockCofirm"), MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    await _companyService.ChangeActiveStatus(company.ProfileId);
                    await ReloadCompaniesAsync();
                }
            }
        }
        private async void ActiveCompany(object parameter)
        {
            if (parameter is Company company)
            {
                var result = MessageBox.Show(LanguageUtil.Translate("ActiveCompanyCofirmMessage"), LanguageUtil.Translate("ActiveCofirm"), MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    await _companyService.ChangeActiveStatus(company.ProfileId);
                    await ReloadCompaniesAsync();
                }
            }
        }

        private async void DeleteCompany(object parameter)
        {
            if (parameter is Company company)
            {
                var result = MessageBox.Show(LanguageUtil.Translate("DeleteCompanyCofirmMessage"), LanguageUtil.Translate("DeleteCofirm"), MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    await _companyService.DeleteCompany(company.ProfileId);
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
