using Employee_And_Company_Management.Commands;
using Employee_And_Company_Management.Data.Entities;
using Employee_And_Company_Management.Helpers;
using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.Services;
using Employee_And_Company_Management.Util;
using Employee_And_Company_Management.Views.Windows.Companies;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ICommand ViewDetailsCommand { get; set; }
        public ICommand AddEmployeeCommand { get; set; }
        public ICommand OpenHireWindowCommand { get; set; }
        public ICommand ConfirmHireCommand { get; set; }
        public ICommand DismissCommand { get; set; }

        private LoginDTO loginDTO;

        private Window window;


        private Company company;

        public EmployeeCompanyViewModel(LoginDTO loginDTO)
        {
            this.loginDTO = loginDTO;
            this._employeeService = new EmployeeService();
            this.departmentsService = new DepartmentsService();
            this.workPlacesService = new WorkPlacesService();
            this.employmentService = new EmploymentService();
            this.companyService = new CompanyService();
            AddEmployeeCommand = new RelayCommand(AddEmployee, CanModifyEmployee);
            OpenHireWindowCommand = new RelayCommand(OpenHireWindow, CanModifyEmployee);
            ConfirmHireCommand = new RelayCommand(ConfirmHire, CanModifyEmployee);
            ViewDetailsCommand = new RelayCommand(OpenDetailsWindow, CanModifyEmployee);
            DismissCommand = new RelayCommand(DissmisEmployment, CanModifyEmployee);
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
            var formerEmployeees = await _employeeService.GetFormerEmployeesInCompany(loginDTO.ProfileId);
            FormerEmployees = new ObservableCollection<Employee>(formerEmployeees);
        }

        private async Task LoadDepartments()
        {
            company = await companyService.GetCompany(loginDTO.ProfileId);
            var departments = await departmentsService.GetDepartmenentsForCompany(loginDTO.ProfileId);
            Departments = new ObservableCollection<Department>(departments);
        }
        private async Task LoadWorkPlaces()
        {
            if (selectedDepartment != null)
            {
                var workplaces = await workPlacesService.GetFreeWorkPlacesInDepartment(selectedDepartment.Id);
                WorkPlaces = new ObservableCollection<WorkPlace>(workplaces);
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
                var result = MessageBox.Show(LanguageUtil.Translate("DeleteEmploymentCofirmMessage"), LanguageUtil.Translate("DeleteCofirm"), MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
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
                MessageBox.Show(LanguageUtil.Translate("AllFieldsRequired"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK, MessageBoxImage.Warning);
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


            await employmentService.AddEmployment(employment);

            MessageBox.Show(LanguageUtil.Translate("EmployeeEmployed"), LanguageUtil.Translate("Information"), MessageBoxButton.OK, MessageBoxImage.Information);
            await LoadEmployees();
            await LoadWorkPlaces();



            window.Close();
            window = null;
        }
    }
}
