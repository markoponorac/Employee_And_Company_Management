using Employee_And_Company_Management.Commands;
using Employee_And_Company_Management.Data.Entities;
using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.Services;
using Employee_And_Company_Management.Views.Windows.Employees;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Employee_And_Company_Management.ViewModels.Employees
{
    public class EmploymentsViewModel : BaseViewModel
    {
        private LoginDTO loginDTO;

        private EmploymentService employmentService;
        private SalariesService salariesService;

        public ICommand ViewSalariesCommand { get; set; }


        private Window salariesWindow;


        private ObservableCollection<Employment> filteredEmployments;
        private ObservableCollection<Salary> salaries;


        public ObservableCollection<Salary> Salaries
        {
            get => salaries;
            set => SetProperty(ref salaries, value);
        }

        public ObservableCollection<Employment> FilteredEmployments
        {
            get => filteredEmployments;
            set => SetProperty(ref filteredEmployments, value);
        }


        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                FilterEmployments();
            }
        }

        private void FilterEmployments()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredEmployments = new ObservableCollection<Employment>(employments);
            }
            else
            {
                FilteredEmployments = new ObservableCollection<Employment>(
                    employments.Where(e => e.CompanyProfile.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || 
                    e.WorkPlace.Title.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || 
                    e.WorkPlace.Department.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                );
            }
        }


        private List<Employment> employments;

        public EmploymentsViewModel(LoginDTO loginDTO)
        {
            this.loginDTO = loginDTO;
            this.employmentService = new EmploymentService();
            this.salariesService = new SalariesService();
            ViewSalariesCommand = new RelayCommand(ExecuteOpenSalariesWindow, CanExecuteOpenSalariesWindow);
            LoadEmployments();
        }

        private bool CanExecuteOpenSalariesWindow(object obj) => true;

        private async void ExecuteOpenSalariesWindow(object obj)
        {
            if (obj is Employment employment)
            {

                var salariesTemp = await salariesService.GetSalariesByEmployment(employment);

                Salaries = new ObservableCollection<Salary>(salariesTemp);

                salariesWindow = new SalariesEmployeeWindow(this);
                salariesWindow.ShowDialog();
            }

        }

        public async void LoadEmployments()
        {
            employments = await employmentService.GetEmploymentsForEmployee(loginDTO.ProfileId);
            FilteredEmployments = new ObservableCollection<Employment>(employments);
        }
    }
}
