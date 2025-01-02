using Employee_And_Company_Management.Commands;
using Employee_And_Company_Management.Data.Entities;
using Employee_And_Company_Management.Helpers.Constants;
using Employee_And_Company_Management.Helpers;
using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.Services;
using Employee_And_Company_Management.Util;
using Employee_And_Company_Management.Views.Windows;
using Employee_And_Company_Management.Views.Windows.Companies;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Employee_And_Company_Management.Views.Windows.Components;

namespace Employee_And_Company_Management.ViewModels.Companies
{
    public class DepartmentCompanyViewModel : BaseViewModel
    {
        private readonly LoginDTO loginDTO;

        private readonly DepartmentsService departmentsService;

        private Window window;

        public String DepartmentName { get; set; }

        public ICommand AddDepartmentCommand { get; set; }
        public ICommand SaveDepartmentCommand { get; set; }
        public ICommand DeleteDepartmentCommand { get; set; }
        public ICommand RestoreDepartmentCommand { get; set; }

        private ObservableCollection<Department> _departments;
        public ObservableCollection<Department> Departments
        {
            get => _departments;
            set => SetProperty(ref _departments, value);
        }
        private ObservableCollection<Department> _deletedDepartments;
        public ObservableCollection<Department> DeletedDepartments
        {
            get => _deletedDepartments;
            set => SetProperty(ref _deletedDepartments, value);
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                FilterDepartments();
            }
        }
        public DepartmentCompanyViewModel(LoginDTO loginDTO)
        {
            this.loginDTO = loginDTO;
            this.departmentsService = new DepartmentsService();
            LoadDepartments();
            AddDepartmentCommand = new RelayCommand(AddDepartment, CanModifyDepartment);
            SaveDepartmentCommand = new RelayCommand(SaveNewDepartment, CanSaveNewDepartment);
            DeleteDepartmentCommand = new RelayCommand(DeleteDepartment, CanModifyDepartment);
            RestoreDepartmentCommand = new RelayCommand(RestoreDepartment, CanModifyDepartment);

        }


        private async Task LoadDepartments()
        {
            var departments = await departmentsService.GetDepartmenentsForCompany(loginDTO.ProfileId);
            Departments = new ObservableCollection<Department>(departments.Where(i => i.IsDeleted == false));
            DeletedDepartments = new ObservableCollection<Department>(departments.Where(i => i.IsDeleted == true));
        }

        private async void FilterDepartments()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                LoadDepartments();
            }
            else
            {
                var departments = await departmentsService.GetDepartmenentsForCompany(loginDTO.ProfileId);
                Departments = new ObservableCollection<Department>(departments.Where(i => i.IsDeleted == false && i.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase)));
                DeletedDepartments = new ObservableCollection<Department>(departments.Where(i => i.IsDeleted == true && i.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase)));
            }
        }



        private bool CanModifyDepartment(object parameter) => true;

        private bool CanSaveNewDepartment(object parameter)
        {

            return true;
        }


        private void AddDepartment(object parameter)
        {
            window = new AddNewDepartmentWindow(this);
            window.ShowDialog();
        }


        private async void DeleteDepartment(object parameter)
        {
            if (parameter is Department department)
            {
                var result = CustomMessageBox.Show(LanguageUtil.Translate("DeleteDepartmentCofirmMessage"), LanguageUtil.Translate("DeleteCofirm"), MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    var temp = await departmentsService.DeleteDepartment(department.Id);
                    if (temp)
                        await ReloadDepartmentsAsync();
                }
            }
        }

        private async void RestoreDepartment(object parameter)
        {
            if (parameter is Department department)
            {
                var result = CustomMessageBox.Show(LanguageUtil.Translate("RestoreDepartmentCofirmMessage"), LanguageUtil.Translate("RestoreConfirm"), MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    var temp = await departmentsService.RestoreDepartment(department.Id);
                    if (temp)
                        await ReloadDepartmentsAsync();
                }
            }
        }


        private async void SaveNewDepartment(object parameter)
        {
            if (string.IsNullOrEmpty(DepartmentName))
            {
                CustomMessageBox.Show(LanguageUtil.Translate("AllFieldsRequired"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
                return;
            }



            Department department = new Department()
            {
                CompanyProfileId = loginDTO.ProfileId,
                Name = DepartmentName,
                IsDeleted = false
            };

            bool result = await departmentsService.AddDepartment(department);
            if (result)
            {
                CustomMessageBox.Show(LanguageUtil.Translate("DepartmentAdded"), LanguageUtil.Translate("Information"), MessageBoxButton.OK);
                await ReloadDepartmentsAsync();
            }
            else
            {
                CustomMessageBox.Show(LanguageUtil.Translate("DepartmentNotAdded"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
            }

            DepartmentName = null;
            window.Close();
            window = null;
        }



        private async Task ReloadDepartmentsAsync()
        {
            var departments = await departmentsService.GetDepartmenentsForCompany(loginDTO.ProfileId);

            Departments.Clear();
            foreach (var department in departments.Where(i => i.IsDeleted == false))
            {
                Departments.Add(department);
            }

            DeletedDepartments.Clear();
            foreach (var department in departments.Where(i => i.IsDeleted == true))
            {
                DeletedDepartments.Add(department);
            }
        }

    }
}
