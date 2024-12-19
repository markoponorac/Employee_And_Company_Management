using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.ViewModels.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Employee_And_Company_Management.Views.Controls.Companies
{
    /// <summary>
    /// Interaction logic for WorkPlacesCompanyControl.xaml
    /// </summary>
    public partial class WorkPlacesCompanyControl : UserControl
    {
        public WorkPlacesCompanyControl(LoginDTO loginDTO)
        {
            InitializeComponent();
            var viewModel = new WorkPlacesViewModel(loginDTO);
            DataContext = viewModel;
        }
    }
}
