using Employee_And_Company_Management.Commands;
using Employee_And_Company_Management.Data.Entities;
using Employee_And_Company_Management.Helpers.Constants;
using Employee_And_Company_Management.Helpers;
using Employee_And_Company_Management.Services;
using Employee_And_Company_Management.Util;
using Employee_And_Company_Management.Views.Windows;
using Employee_And_Company_Management.Views.Windows.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using Employee_And_Company_Management.Views.Windows.Components;

namespace Employee_And_Company_Management.ViewModels.Admin
{
    public class QualificationAdminViewModel : BaseViewModel
    {
        public ICommand AddQualificationCommand { get; set; }
        public ICommand SaveQualification { get; set; }

        private string _qualificationTitle;
        private string _qualificationCode;

        public string QualificationTitle
        {
            get => _qualificationTitle;
            set
            {
                SetProperty(ref _qualificationTitle, value);
            }
        }
        public string QualificationCode
        {
            get => _qualificationCode;
            set
            {
                SetProperty(ref _qualificationCode, value);
            }
        }

        private readonly QualificationsServis qualificationsServis;

        private ObservableCollection<QualificationLevel> _qualifications;
        public ObservableCollection<QualificationLevel> Qualifications
        {
            get => _qualifications;
            set => SetProperty(ref _qualifications, value);
        }


        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                FilterQualifications();
            }
        }
        public QualificationAdminViewModel()
        {
            qualificationsServis = new QualificationsServis();
            AddQualificationCommand = new RelayCommand(AddQualification, CanModifyQualification);
            SaveQualification = new RelayCommand(ExecuteSaveQualification, CanModifyQualification);
            LoadQualifications();
            Thread.Sleep(100);
        }

        private bool CanModifyQualification(object parameter) => true;

        private Window window;
        private void AddQualification(object parameter)
        {
            window = new AddQualificationWindow(this);
            window.ShowDialog();
        }

        private async void ExecuteSaveQualification(object parameter)
        {
            if (string.IsNullOrEmpty(QualificationTitle) || string.IsNullOrEmpty(QualificationCode))
            {
                CustomMessageBox.Show(LanguageUtil.Translate("AllFieldsRequired"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
                return;
            }

            QualificationLevel qualificationLevel = new QualificationLevel()
            {
                Title = QualificationTitle,
                QualificationCode = QualificationCode
            };

            bool result = await qualificationsServis.AddQualification(qualificationLevel);
            if (result)
            {
                CustomMessageBox.Show(LanguageUtil.Translate("QualificationAdded"), LanguageUtil.Translate("Information"), MessageBoxButton.OK);
                await ReloadQualificationsAsync();
            }
            else
            {
                CustomMessageBox.Show(LanguageUtil.Translate("QualificationNotAdded"), LanguageUtil.Translate("Warning"), MessageBoxButton.OK);
            }
            window.Close();
            window = null;
            QualificationTitle = string.Empty;
            QualificationCode = string.Empty;
        }

        private async void LoadQualifications()
        {
            var qualifications = await qualificationsServis.GetQualificationLevels();
            Qualifications = new ObservableCollection<QualificationLevel>(qualifications);

        }


        private async void FilterQualifications()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                LoadQualifications();
            }
            else
            {
                var qualifications = await qualificationsServis.GetQualificationLevels();
                Qualifications = new ObservableCollection<QualificationLevel>(qualifications.Where(i => i.Title.Contains(SearchText, StringComparison.OrdinalIgnoreCase)));


            }
        }

        private async Task ReloadQualificationsAsync()
        {
            var qualifications = await qualificationsServis.GetQualificationLevels();

            Qualifications.Clear();
            foreach (var qualification in qualifications)
            {
                Qualifications.Add(qualification);
            }

        }
    }
}
