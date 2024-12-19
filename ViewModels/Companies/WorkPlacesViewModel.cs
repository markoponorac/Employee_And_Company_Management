using Employee_And_Company_Management.Commands;
using Employee_And_Company_Management.Data.Entities;
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
using System.Windows.Controls;
using System.Windows.Input;

namespace Employee_And_Company_Management.ViewModels.Companies
{
    public class WorkPlacesViewModel : BaseViewModel
    {
        private LoginDTO loginDTO;

        private readonly DepartmentsService departmentsService;
        private readonly WorkPlacesService workPlacesService;

        private Window window;

        private Department selectedDepartment;

        public ICommand AddWorkPlaceCommand { get; set; }
        public ICommand SaveWorkPlaceCommand { get; set; }
        public ICommand DeleteWorkPlaceCommand { get; set; }
        public ICommand RestoreWorkPlaceCommand { get; set; }

        public Department SelectedDepartmentAdd {  get; set; }
        public string WorkPlaceName { get; set; }
        public string WorkPlaceDescription { get; set; }
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


        public ObservableCollection<Department> Departments { get; set; }

        private ObservableCollection<WorkPlace> activeWorkPlaces;
        public ObservableCollection<WorkPlace> ActiveWorkPlaces
        {
            get => activeWorkPlaces;
            set => SetProperty(ref activeWorkPlaces, value);
        }

        private ObservableCollection<WorkPlace> deletedWorkPlaces;
        public ObservableCollection<WorkPlace> DeletedWorkPlaces
        {
            get => deletedWorkPlaces;
            set => SetProperty(ref deletedWorkPlaces, value);
        }


        public WorkPlacesViewModel(LoginDTO loginDTO)
        {
            this.loginDTO = loginDTO;
            this.departmentsService = new DepartmentsService();
            this.workPlacesService = new WorkPlacesService();
            AddWorkPlaceCommand = new RelayCommand(AddWorkPlace, CanModifyWorkPlace);
            SaveWorkPlaceCommand = new RelayCommand(SaveWorkPlace, CanSaveWorkPlace);
            DeleteWorkPlaceCommand = new RelayCommand(DeleteWorkPlace, CanModifyWorkPlace);
            RestoreWorkPlaceCommand = new RelayCommand(RestoreWorkPlace, CanModifyWorkPlace);
            LoadDepartments();
            Thread.Sleep(200);
        }


        private bool CanModifyWorkPlace(object parameter) => true;
        private bool CanSaveWorkPlace(object parameter) => true;

        private void AddWorkPlace(object parameter)
        {
            window = new AddNewWorkPlaceWindow(this);
            window.ShowDialog();
        }
        private async void SaveWorkPlace(object parameter)
        {
            if (string.IsNullOrEmpty(WorkPlaceName) || SelectedDepartmentAdd== null)
            {
                MessageBox.Show(LanguageUtil.Translate("AllFieldsRequired"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }



            WorkPlace workPlace = new WorkPlace()
            {
                Department = SelectedDepartmentAdd,
                DepartmentId = SelectedDepartmentAdd.Id,
                Title = WorkPlaceName,
                Description = WorkPlaceDescription
            };

            bool result = await workPlacesService.AddWorkPlace(workPlace);
            if (result)
            {
                MessageBox.Show(LanguageUtil.Translate("WorkPlaceAdded"), LanguageUtil.Translate("Information"), MessageBoxButton.OK, MessageBoxImage.Information);
                await ReloadWorkPlaces();
            }
            else
            {
                MessageBox.Show(LanguageUtil.Translate("WorkPlaceNotAdded"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            SelectedDepartmentAdd = null;
            WorkPlaceName = null;
            WorkPlaceDescription = null;
            window.Close();
            window = null;
        }


        private async Task LoadDepartments()
        {
            var departments = await departmentsService.GetDepartmenentsForCompany(loginDTO.ProfileId);
            Departments = new ObservableCollection<Department>(departments.Where(i => i.IsDeleted == false)); 
            if(departments.Count()>0)
            {
                SelectedDepartment = departments[0];
            }
        }


        private async Task LoadWorkPlaces()
        {
            if (selectedDepartment != null)
            {

                var workPlaces = await workPlacesService.GetWorkPlacesInDepartment(selectedDepartment.Id);
                
                if(ActiveWorkPlaces == null)
                {
                    ActiveWorkPlaces = new ObservableCollection<WorkPlace>(workPlaces.Where(i => i.IsDeleted == false));
                    DeletedWorkPlaces = new ObservableCollection<WorkPlace>(workPlaces.Where(i => i.IsDeleted == true));
                }
                else
                {
                    ActiveWorkPlaces.Clear();
                    foreach (var workPlace in workPlaces.Where(i => i.IsDeleted == false))
                    {
                        ActiveWorkPlaces.Add(workPlace);
                    }

                    DeletedWorkPlaces.Clear();
                    foreach (var workPlace in workPlaces.Where(i => i.IsDeleted == true))
                    {
                        DeletedWorkPlaces.Add(workPlace);
                    }
                }
            }

        }


        private async Task ReloadWorkPlaces()
        {
           if(selectedDepartment != null)
            {
                var workPlaces = await workPlacesService.GetWorkPlacesInDepartment(selectedDepartment.Id);
                ActiveWorkPlaces.Clear();
                foreach (var workPlace in workPlaces.Where(i => i.IsDeleted == false))
                {
                    ActiveWorkPlaces.Add(workPlace);
                }

                DeletedWorkPlaces.Clear();
                foreach (var workPlace in workPlaces.Where(i => i.IsDeleted == true))
                {
                    DeletedWorkPlaces.Add(workPlace);
                }
            }
        }



        private async void DeleteWorkPlace(object parameter)
        {
            if (parameter is WorkPlace workPlace)
            {
                var result = MessageBox.Show(LanguageUtil.Translate("DeleteWorkPlaceCofirmMessage"), LanguageUtil.Translate("DeleteCofirm"), MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    await workPlacesService.DeleteWorkPlace(workPlace.Id);
                    await ReloadWorkPlaces();
                }
            }
        }
        private async void RestoreWorkPlace(object parameter)
        {
            if (parameter is WorkPlace workPlace)
            {
                var result = MessageBox.Show(LanguageUtil.Translate("RestoreWorkPlaceCofirmMessage"), LanguageUtil.Translate("DeleteCofirm"), MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    await workPlacesService.RestoreWorkPlace(workPlace.Id);
                    await ReloadWorkPlaces();
                }
            }
        }

    }
}
