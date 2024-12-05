using Employee_And_Company_Management.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Employee_And_Company_Management.Views.Controls
{
    public partial class GeneralSettingsControl : UserControl
    {
        public GeneralSettingsControl()
        {
            InitializeComponent();
            var viewModel = new GeneralSettingsControlViewModel();
            DataContext = viewModel;
        }

       
    }
}
