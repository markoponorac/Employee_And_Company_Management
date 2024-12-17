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


        public ObservableCollection<Department> Departments { get; set; }
        public ObservableCollection<Department> DeletedDepartments { get; set; }
        public DepartmentCompanyViewModel(LoginDTO loginDTO)
        {
            this.loginDTO = loginDTO;
            this.departmentsService = new DepartmentsService();
            LoadDepartments();
            AddDepartmentCommand = new RelayCommand(AddDepartment, CanModifyDepartment);
            SaveDepartmentCommand = new RelayCommand(SaveNewDepartment, CanSaveNewDepartment);
            DeleteDepartmentCommand = new RelayCommand(DeleteDepartment, CanModifyDepartment);
            RestoreDepartmentCommand = new RelayCommand(RestoreDepartment, CanModifyDepartment);

            Thread.Sleep(200);

        }


        private async Task LoadDepartments()
        {
            var departments = await departmentsService.GetDepartmenentsForCompany(loginDTO.ProfileId);
            Departments = new ObservableCollection<Department>(departments.Where(i => i.IsDeleted == false));
            DeletedDepartments = new ObservableCollection<Department>(departments.Where(i => i.IsDeleted == true));
        }


        private bool CanModifyDepartment(object parameter) => true;

        private bool CanSaveNewDepartment(object parameter)
        {
            //if(string.IsNullOrEmpty(DepartmentName))
            //{
            //    return false;
            //}
            return true;
        }


        private void AddDepartment(object parameter)
        {
            window = new AddNewDepartmentWindow(this);
            window.ShowDialog();
        }


        private async void DeleteDepartment (object parameter)
        {
            if (parameter is Department department)
            {
                var result = MessageBox.Show(LanguageUtil.Translate("DeleteDepartmentCofirmMessage"), LanguageUtil.Translate("DeleteCofirm"), MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    await departmentsService.DeleteDepartment(department.Id);
                    await ReloadDepartmentsAsync();
                }
            }
        }

        private async void RestoreDepartment(object parameter)
        {
            if (parameter is Department department)
            {
                var result = MessageBox.Show(LanguageUtil.Translate("RestoreDepartmentCofirmMessage"), LanguageUtil.Translate("DeleteCofirm"), MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    await departmentsService.RestoreDepartment(department.Id);
                    await ReloadDepartmentsAsync();
                }
            }
        }


        private async void SaveNewDepartment(object parameter)
        {
            if (string.IsNullOrEmpty(DepartmentName))
            {
                MessageBox.Show(LanguageUtil.Translate("AllFieldsRequired"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK, MessageBoxImage.Warning);
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
                MessageBox.Show(LanguageUtil.Translate("DepartmentAdded"), LanguageUtil.Translate("Information"), MessageBoxButton.OK, MessageBoxImage.Information);
                await ReloadDepartmentsAsync();
            }
            else
            {
                MessageBox.Show(LanguageUtil.Translate("DepartmentNotAdded"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK, MessageBoxImage.Warning);
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
