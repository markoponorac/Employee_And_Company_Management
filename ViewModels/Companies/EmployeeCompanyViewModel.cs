using Employee_And_Company_Management.Commands;
using Employee_And_Company_Management.Data.Entities;
using Employee_And_Company_Management.Helpers;
using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.Services;
using Employee_And_Company_Management.Util;
using Employee_And_Company_Management.Views.Windows.Companies;
using Employee_And_Company_Management.Views.Windows.Components;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Employee_And_Company_Management.ViewModels.Companies
{
    public class EmployeeCompanyViewModel :BaseViewModel
    {
        private readonly EmployeeService _employeeService;
        private readonly DepartmentsService departmentsService;
        private readonly WorkPlacesService workPlacesService;
        private readonly EmploymentService employmentService;
        private readonly CompanyService companyService;
        private readonly SalariesService salariesService;

        private ObservableCollection<Employee> currentlyEmployed;
        public ObservableCollection<Employee> CurrentlyEmployed
        {
            get => currentlyEmployed;
            set => SetProperty(ref currentlyEmployed, value);
        }
        private ObservableCollection<Employee> formerEmployees;
        public ObservableCollection<Employee> FormerEmployees
        {
            get => formerEmployees;
            set => SetProperty(ref formerEmployees, value);
        }
        private ObservableCollection<Salary> salaries;
        public ObservableCollection<Salary> Salaries
        {
            get => salaries;
            set => SetProperty(ref salaries, value);
        }

        private ObservableCollection<Employee> availableEmployees;
        public ObservableCollection<Employee> AvailableEmployees
        {
            get => availableEmployees;
            set => SetProperty(ref availableEmployees, value);
        }

        private ObservableCollection<Department> departments;
        public ObservableCollection<Department> Departments
        {
            get => departments;
            set => SetProperty(ref departments, value);
        }

        private ObservableCollection<Employment> employmentHistory;
        public ObservableCollection<Employment> EmploymentHistory
        {
            get => employmentHistory;
            set => SetProperty(ref employmentHistory, value);
        }

        private WorkPlace selectedWorkPlace;
        public WorkPlace SelectedWorkPlace
        {
            get => selectedWorkPlace;
            set => SetProperty(ref selectedWorkPlace, value);
        }

        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set => SetProperty(ref selectedEmployee, value);
        }


        private Employee selectedEmployeeDetails;
        public Employee SelectedEmployeeDetails
        {
            get => selectedEmployeeDetails;
            set => SetProperty(ref selectedEmployeeDetails, value);
        }



        private DateTime? hireDate;

        public DateTime? HireDate
        {
            get => hireDate;
            set => SetProperty(ref hireDate, value);
        }

        private double hourlyRate;
        public double HourlyRate
        {
            get => hourlyRate;
            set => SetProperty(ref hourlyRate, value);
        }

        private int vacationDays;
        public int VacationDays
        {
            get => vacationDays;
            set => SetProperty(ref vacationDays, value);
        }


        private Department selectedDepartment;
        public Department SelectedDepartment
        {
            get => selectedDepartment;
            set
            {
                if (SetProperty(ref selectedDepartment, value))
                {
                    if (selectedDepartment != null)
                    {
                        _ = LoadWorkPlaces();
                    }
                }
            }
        }

        private ObservableCollection<WorkPlace> workPlaces;
        public ObservableCollection<WorkPlace> WorkPlaces
        {
            get => workPlaces;
            set => SetProperty(ref workPlaces, value);
        }

        private string _selectedMonth;
        private int _selectedMonthInt;
        private int _year;
        private double _amount;
        private DateOnly _paymentDate = DateOnly.FromDateTime(DateTime.Now);

        public List<string> Months { get; } = MonthUtil.Months;

        public string SelectedMonth
        {
            get => _selectedMonth;
            set{
                SetProperty(ref _selectedMonth, value);
                _selectedMonthInt = MonthUtil.GetMonth(SelectedMonth);
            }
        }

        public int Year
        {
            get => _year;
            set => SetProperty(ref _year, value);
        }

        public double Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value);
        }

        public DateOnly PaymentDate
        {
            get => _paymentDate;
            set => SetProperty(ref _paymentDate, value);
        }



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


        public ICommand ViewDetailsCommand { get; set; }
        public ICommand AddEmployeeCommand { get; set; }
        public ICommand OpenHireWindowCommand { get; set; }
        public ICommand ConfirmHireCommand { get; set; }
        public ICommand DismissCommand { get; set; }
        public ICommand ViewSalariesCommand { get; set; }
        public ICommand ViewFormerEmployeeSalariesCommand { get; set; }
        public ICommand AddNewSalaryCommand { get; set; }
        public ICommand SaveNewSalaryCommand { get; set; }

        private LoginDTO loginDTO;

        private Window window;
        private Window salariesWindow;
        private Window addSalariesWindow;


        private Company company;

        public EmployeeCompanyViewModel(LoginDTO loginDTO)
        {
            this.loginDTO = loginDTO;
            this._employeeService = new EmployeeService();
            this.departmentsService = new DepartmentsService();
            this.workPlacesService = new WorkPlacesService();
            this.employmentService = new EmploymentService();
            this.companyService = new CompanyService();
            this.salariesService = new SalariesService();
            AddEmployeeCommand = new RelayCommand(AddEmployee, CanModifyEmployee);
            OpenHireWindowCommand = new RelayCommand(OpenHireWindow, CanModifyEmployee);
            ConfirmHireCommand = new RelayCommand(ConfirmHire, CanModifyEmployee);
            ViewDetailsCommand = new RelayCommand(OpenDetailsWindow, CanModifyEmployee);
            DismissCommand = new RelayCommand(DissmisEmployment, CanModifyEmployee);
            ViewSalariesCommand = new RelayCommand(OpenSalariesWindow, CanModifyEmployee);
            ViewFormerEmployeeSalariesCommand = new RelayCommand(OpenFormerEmployeeSalariesWindow, CanModifyEmployee);
            AddNewSalaryCommand = new RelayCommand(OpenAddSalariesWindow, CanModifyEmployee);
            SaveNewSalaryCommand = new RelayCommand(SaveNewSalary, CanModifyEmployee);
            LoadEmployees();
            LoadDepartments();
            LoadWorkPlaces();
        }


        private async Task LoadEmployees()
        {
            var unemployedEmployees = await _employeeService.GetUnemployedEmployees();
            AvailableEmployees = new ObservableCollection<Employee>(unemployedEmployees);
            var currentlyEmployed = await _employeeService.GetCurrentlyEmployedInCompany(loginDTO.ProfileId);
            CurrentlyEmployed = new ObservableCollection<Employee>(currentlyEmployed);
            var tempFormerEmployees = await _employeeService.GetFormerEmployeesInCompany(loginDTO.ProfileId);

            var currentlyEmployedIds = new HashSet<int>(currentlyEmployed.Select(e => e.PersonProfileId));
            var filteredFormerEmployees = tempFormerEmployees.Where(e => !currentlyEmployedIds.Contains(e.PersonProfileId));
            FormerEmployees = new ObservableCollection<Employee>(filteredFormerEmployees);
        }


        private async void FilterEmployees()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                LoadEmployees();
            }
            else
            {
                var employees = await _employeeService.GetUnemployedEmployees();
                AvailableEmployees = new ObservableCollection<Employee>(employees.Where(e => e.PersonProfile.FirstName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || e.PersonProfile.LastName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || e.PersonProfile.Profile.Username.Contains(SearchText, StringComparison.OrdinalIgnoreCase)));
                var currentlyEmployed = await _employeeService.GetCurrentlyEmployedInCompany(loginDTO.ProfileId);
                CurrentlyEmployed = new ObservableCollection<Employee>(currentlyEmployed.Where(e => e.PersonProfile.FirstName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || e.PersonProfile.LastName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || e.PersonProfile.Profile.Username.Contains(SearchText, StringComparison.OrdinalIgnoreCase)));
                
                var tempFormerEmployees = await _employeeService.GetFormerEmployeesInCompany(loginDTO.ProfileId);
                var currentlyEmployedIds = new HashSet<int>(currentlyEmployed.Select(e => e.PersonProfileId));
                var filteredFormerEmployees = tempFormerEmployees.Where(e => !currentlyEmployedIds.Contains(e.PersonProfileId));

                FormerEmployees = new ObservableCollection<Employee>(filteredFormerEmployees.Where(e => e.PersonProfile.FirstName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || e.PersonProfile.LastName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || e.PersonProfile.Profile.Username.Contains(SearchText, StringComparison.OrdinalIgnoreCase)));

            }
        }

        private async Task LoadDepartments()
        {
            company = await companyService.GetCompany(loginDTO.ProfileId);
            var departments = await departmentsService.GetDepartmenentsForCompany(loginDTO.ProfileId);
            Departments = new ObservableCollection<Department>(departments.Where(i=> !i.IsDeleted));
        }
        private async Task LoadWorkPlaces()
        {
            if (selectedDepartment != null)
            {
                var workplaces = await workPlacesService.GetFreeWorkPlacesInDepartment(selectedDepartment.Id);
                WorkPlaces = new ObservableCollection<WorkPlace>(workplaces.Where(i => !i.IsDeleted));
            }
        }

        private async Task LoadSalaries()
        {
            if (selectedEmployee != null)
            {
                var salariesTemp = await salariesService.GetSalariesByEmployeeAndCompany(selectedEmployee.PersonProfileId, loginDTO.ProfileId);
                Salaries = new ObservableCollection<Salary>(salariesTemp);
            }
        }

        private bool CanModifyEmployee(object parameter) => true;

        private void AddEmployee(object parameter)
        {
            window = new AddNewEmployeeWindow(this);
            window.ShowDialog();
        }

        private void OpenHireWindow(object parameter)
        {
            if (parameter is Employee employee)
            {
                selectedEmployee = employee;
                window = new HireEmployeeWindow(this);
                window.ShowDialog();
            }

            
        }


        private void OpenSalariesWindow(object parameter)
        {
            if (parameter is Employee employee)
            {
                selectedEmployee = employee;
                
                LoadSalaries();
                salariesWindow = new SalariesWindow(this);
                salariesWindow.ShowDialog();
            }


        }

        private void OpenFormerEmployeeSalariesWindow(object parameter)
        {
            if (parameter is Employee employee)
            {
                selectedEmployee = employee;

                LoadSalaries();
                salariesWindow = new FormerEmployeesSalariesWindow(this);
                salariesWindow.ShowDialog();
            }


        }

        private void OpenAddSalariesWindow(object parameter)
        {

            addSalariesWindow =  new AddSalaryWindow (this);
            addSalariesWindow.ShowDialog();


        }



        private async void SaveNewSalary(object parameter)
        {
            if (Amount <= 0.0 || PaymentDate == null || _selectedMonthInt < 1 || _selectedMonthInt > 12 || Year > DateTime.Now.Year || Year == 0)
            {
                CustomMessageBox.Show(LanguageUtil.Translate("AllFieldsRequired"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
                return;
            }

            Salary salary = new Salary()
            {
                Amount = (decimal)Amount,
                PaymentDate = PaymentDate,
                ForMonth = _selectedMonthInt,
                ForYear = Year
            };

            bool result = await salariesService.AddSalaryForEmployeeAndCompany(salary, selectedEmployee.PersonProfileId, loginDTO.ProfileId);
            if (result) {
                CustomMessageBox.Show(LanguageUtil.Translate("SalaryAdded"), LanguageUtil.Translate("Information"), MessageBoxButton.OK);

                LoadSalaries();
            }
            else
            {
                CustomMessageBox.Show(LanguageUtil.Translate("SalaryNotAdded"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
            }
            addSalariesWindow.Close();


        }

        private async void OpenDetailsWindow(object parameter)
        {
            if (parameter is Employee employee)
            {
                SelectedEmployeeDetails = employee;

                var employments = await employmentService.GetEmploymentsForEmployee(selectedEmployeeDetails.PersonProfileId);
                EmploymentHistory = new ObservableCollection<Employment>(employments);

                Window window2 = new EmployeeDetailsWindow(this);
                window2.ShowDialog();
            }


        }


        private async void DissmisEmployment(object parameter)
        {
            if (parameter is Employee employee)
            {
                SelectedEmployeeDetails = employee;
                var result = CustomMessageBox.Show(LanguageUtil.Translate("DeleteEmploymentCofirmMessage"), LanguageUtil.Translate("DeleteCofirm"), MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    await employmentService.EndEmployment(SelectedEmployeeDetails);
                    await LoadWorkPlaces();
                    await LoadEmployees();
                }
              
            }


        }

        private async void ConfirmHire(object parameter)
        {
            if (selectedDepartment == null || selectedWorkPlace == null || hireDate == null || hourlyRate <= 0.0 || vacationDays <= 0)
            {
                CustomMessageBox.Show(LanguageUtil.Translate("AllFieldsRequired"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
                return;
            }



            Employment employment = new Employment()
            {
                EmployedFrom = (DateOnly)DateConverter.ConvertToDateOnly(hireDate),
                PriceOfWork = (decimal)hourlyRate,
                NumberOfDaysOff = vacationDays,
                WorkPlace = selectedWorkPlace,
                WorkPlaceId = selectedDepartment.Id,
                EmployeePersonProfile = SelectedEmployee,
                EmployeePersonProfileId = SelectedEmployee.PersonProfileId,
                CompanyProfile = company,
                CompanyProfileId = company.ProfileId
            };


            var result = await employmentService.AddEmployment(employment);
            if(result)
            {
                CustomMessageBox.Show(LanguageUtil.Translate("EmployeeEmployed"), LanguageUtil.Translate("Information"), MessageBoxButton.OK);
                await LoadEmployees();
                await LoadWorkPlaces();
            }
            else
            {
                CustomMessageBox.Show(LanguageUtil.Translate("EmployeeNotEmployed"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
            }



            window.Close();
            window = null;
        }
    }
}
