using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.Util;
using Employee_And_Company_Management.ViewModels.Companies;
using System.Windows;

namespace Employee_And_Company_Management.Views.Windows.Companies
{
    public partial class CompanyWindow : Window
    {
        private readonly LoginDTO _loginDTO;
        public CompanyWindow(LoginDTO loginDTO )
        {
            InitializeComponent();
            _loginDTO = loginDTO;
            LanguageUtil.ChangeLanguage(_loginDTO.Language); 
            ThemeUtil.ChangeTheme(_loginDTO.Theme);
            var viewModel = new CompanyViewModel(loginDTO);
            DataContext = viewModel;

            Loaded += (s, e) => viewModel.InitialNavigation();
        }


    }
}