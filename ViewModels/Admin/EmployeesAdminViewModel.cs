using Employee_And_Company_Management.Commands;
using Employee_And_Company_Management.Data.Entities;
using Employee_And_Company_Management.Helpers;
using Employee_And_Company_Management.Helpers.Constants;
using Employee_And_Company_Management.Services;
using Employee_And_Company_Management.Util;
using Employee_And_Company_Management.Views.Windows;
using Employee_And_Company_Management.Views.Windows.Components;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Employee_And_Company_Management.ViewModels.Admin
{
    public class EmployeesAdminViewModel : BaseViewModel
    {
        private readonly EmployeeService _employeeService;
        private readonly QualificationsServis _qualificationsServis;


        private ObservableCollection<Employee> _activeEmplpyees;
        public ObservableCollection<Employee> ActiveEmployees
        {
            get => _activeEmplpyees;
            set => SetProperty(ref _activeEmplpyees, value);
        }

        private ObservableCollection<Employee> _blockedEmployees;
        public ObservableCollection<Employee> BlockedEmployees
        {
            get => _blockedEmployees;
            set => SetProperty(ref _blockedEmployees, value);
        }

        private ObservableCollection<Employee> _deletedEmployees;
        public ObservableCollection<Employee> DeletedEmployees
        {
            get => _deletedEmployees;
            set => SetProperty(ref _deletedEmployees, value);
        }

        public ICommand BlockCommand { get; set; }
        public ICommand ActiveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ViewDetailsCommand { get; set; }
        public ICommand AddEmployeeCommand { get; set; }

        private string _username;
        private string _firstName;
        private string _lastName;
        private DateTime? _dateOfBirth;
        private string _jmb;
        private int _selectedQualificationId;
        private string _password;
        private string _confirmedPassword;
        private ObservableCollection<QualificationLevel> _qualifications;


        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                FilterEmployees();
            }
        }

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
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

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public DateTime? DateOfBirth
        {
            get => _dateOfBirth;
            set => SetProperty(ref _dateOfBirth, value);
        }

        public string Jmb
        {
            get => _jmb;
            set => SetProperty(ref _jmb, value);
        }

        public ObservableCollection<QualificationLevel> Qualifications
        {
            get => _qualifications;
            set => SetProperty(ref _qualifications, value);
        }

        public int SelectedQualificationId
        {
            get => _selectedQualificationId;
            set => SetProperty(ref _selectedQualificationId, value);
        }
        public ICommand SaveCommand { get; set; }


        public EmployeesAdminViewModel()
        {
            _employeeService = new EmployeeService();
            _qualificationsServis = new QualificationsServis();
            BlockCommand = new RelayCommand(BlockEmployee, CanModifyEmployee);
            DeleteCommand = new RelayCommand(DeleteEmployee, CanModifyEmployee);
            ViewDetailsCommand = new RelayCommand(ViewDetails, CanModifyEmployee);
            AddEmployeeCommand = new RelayCommand(AddEmployee, CanModifyEmployee);
            ActiveCommand = new RelayCommand(ActiveEmployee, CanModifyEmployee);
            SaveCommand = new RelayCommand(SaveNewEmployee, CanSaveNewEmployee);
            LoadEmployees();
            Thread.Sleep(100);
        }

        private async void LoadEmployees()
        {
            var employees = await _employeeService.getEmployees();
            ActiveEmployees = new ObservableCollection<Employee>(employees.Where(e => !e.PersonProfile.Profile.IsDeleted && e.PersonProfile.Profile.IsActive));
            BlockedEmployees = new ObservableCollection<Employee>(employees.Where(e => !e.PersonProfile.Profile.IsDeleted && !e.PersonProfile.Profile.IsActive));
            DeletedEmployees = new ObservableCollection<Employee>(employees.Where(e => e.PersonProfile.Profile.IsDeleted));
            var qualifications = await _qualificationsServis.GetQualificationLevels();
            Qualifications = new ObservableCollection<QualificationLevel>(qualifications);
        }


        private async void FilterEmployees()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                LoadEmployees();
            }
            else
            {
                var employees = await _employeeService.getEmployees();
                ActiveEmployees = new ObservableCollection<Employee>(employees.Where(e => !e.PersonProfile.Profile.IsDeleted && e.PersonProfile.Profile.IsActive 
                && (e.PersonProfile.FirstName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || e.PersonProfile.LastName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || e.PersonProfile.Profile.Username.Contains(SearchText, StringComparison.OrdinalIgnoreCase))));
                BlockedEmployees = new ObservableCollection<Employee>(employees.Where(e => !e.PersonProfile.Profile.IsDeleted && !e.PersonProfile.Profile.IsActive
                && (e.PersonProfile.FirstName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || e.PersonProfile.LastName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || e.PersonProfile.Profile.Username.Contains(SearchText, StringComparison.OrdinalIgnoreCase))));
                DeletedEmployees = new ObservableCollection<Employee>(employees.Where(e => e.PersonProfile.Profile.IsDeleted && (e.PersonProfile.FirstName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || e.PersonProfile.LastName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || e.PersonProfile.Profile.Username.Contains(SearchText, StringComparison.OrdinalIgnoreCase))));

            }
        }

        private async void BlockEmployee(object parameter)
        {
            if (parameter is Employee employee)
            {
                var result = CustomMessageBox.Show(LanguageUtil.Translate("BlockEmployeeCofirmMessage"), LanguageUtil.Translate("BlockCofirm"), MessageBoxButton.YesNoCancel);
                
                if (result == MessageBoxResult.Yes)
                {
                    await _employeeService.ChangeActiveStatus(employee.PersonProfileId);
                    await ReloadEmployeesAsync();
                }
            }
        }

        private async void ActiveEmployee(object parameter)
        {
            if (parameter is Employee employee)
            {
                var result = CustomMessageBox.Show(LanguageUtil.Translate("ActiveEmployeeCofirmMessage"), LanguageUtil.Translate("ActiveCofirm"), MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    bool temp = await _employeeService.ChangeActiveStatus(employee.PersonProfileId);
                    if (temp)
                    {
                        await ReloadEmployeesAsync();
                    }
                }
            }
        }

        private async void DeleteEmployee(object parameter)
        {
            if (parameter is Employee employee)
            {
                var result = CustomMessageBox.Show(LanguageUtil.Translate("DeleteEmployeeCofirmMessage"), LanguageUtil.Translate("DeleteCofirm"), MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    bool temp = await _employeeService.DeleteEmployee(employee.PersonProfileId);
                    if (temp)
                    {
                        await ReloadEmployeesAsync();
                    }
                }
            }
        }

        private void ViewDetails(object parameter)
        {
            if (parameter is Employee employee)
            {
                Window window = new EmployeeDetailsWindow(employee);
                window.ShowDialog();
            }
        }
        Window window;
        private void AddEmployee(object parameter)
        {
            window = new AddNewEmployeeWindow(this);
            window.ShowDialog();
        }



        private async void SaveNewEmployee(object parameter)
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(Jmb) ||
                string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmedPassword) || SelectedQualificationId <= 0 || DateOfBirth == null)
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
            if (Jmb.Length != 13 || !Jmb.All(char.IsDigit))
            {
                CustomMessageBox.Show(LanguageUtil.Translate("JmbIncorect"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
                return;
            }
            if(DateOfBirth > DateTime.Now)
            {
                CustomMessageBox.Show(LanguageUtil.Translate("DateIncorrect"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
                return;
            }

            string temp = DateOfBirth.Value.ToString();
            temp = temp.Remove(4, 1);

            if (!Jmb.StartsWith(temp))
            {
                CustomMessageBox.Show(LanguageUtil.Translate("JMBAndDofBMissmetch"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
                return;
            }
            Employee employee = new Employee()
            {
                DateOfBirth = (DateOnly)DateConverter.ConvertToDateOnly(DateOfBirth),
                IsEmployed = false,
                QualificationLevelId = SelectedQualificationId,
                PersonProfile = new Person()
                {
                    Jmb = Jmb,
                    FirstName = FirstName,
                    LastName = LastName,
                    Profile = new Profile()
                    {
                        Username = Username,
                        Password = Password,
                        Theme = "BlueTheme",
                        Language = "en-US",
                        IsActive = true,
                        IsDeleted = false
                    }
                }
            };

            bool result = await _employeeService.AddEmployee(employee);
            if (result)
            {
                CustomMessageBox.Show(LanguageUtil.Translate("EmployeeAdded"), LanguageUtil.Translate("Information"), MessageBoxButton.OK);
                await ReloadEmployeesAsync();
            }
            else
            {
                CustomMessageBox.Show(LanguageUtil.Translate("EmployeeNotAdded"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
            }
            Username = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = null;
            Jmb = string.Empty;
            SelectedQualificationId = 0;
            window.Close();
            window = null;
        }

        private bool CanModifyEmployee(object parameter) => true;
        private bool CanSaveNewEmployee(object parameter)
        {
            return true;
        }

        private async Task ReloadEmployeesAsync()
        {
            var employees = await _employeeService.getEmployees();

            ActiveEmployees.Clear();
            foreach (var employee in employees.Where(e => !e.PersonProfile.Profile.IsDeleted && e.PersonProfile.Profile.IsActive))
            {
                ActiveEmployees.Add(employee);
            }

            BlockedEmployees.Clear();
            foreach (var employee in employees.Where(e => !e.PersonProfile.Profile.IsDeleted && !e.PersonProfile.Profile.IsActive))
            {
                BlockedEmployees.Add(employee);
            }

            DeletedEmployees.Clear();
            foreach (var employee in employees.Where(e => e.PersonProfile.Profile.IsDeleted))
            {
                DeletedEmployees.Add(employee);
            }
        }
    }
}
