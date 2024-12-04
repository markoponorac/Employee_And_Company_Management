using Employee_And_Company_Management.Commands;
using Employee_And_Company_Management.Views.Controls.Admin;
using System.Windows.Controls;
using System.Windows.Input;

namespace Employee_And_Company_Management.ViewModels
{
    public class AdministratorViewModel : BaseViewModel
    {
        private Control _currentPage;
        public Control CurrentPage
        {
            get => _currentPage;
            set => SetProperty(ref _currentPage, value);
        }

        public ICommand NavigateToSettingsCommand { get; set; }

        public AdministratorViewModel()
        {
            NavigateToSettingsCommand = new RelayCommand(ExecuteNavigateToSettings, CanExecuteNavigateToSettings);
        }

        private bool CanExecuteNavigateToSettings(object obj) => true;

        private void ExecuteNavigateToSettings(object obj)
        {
            CurrentPage = new AdministratorSettingsControl();
        }
    }

}
