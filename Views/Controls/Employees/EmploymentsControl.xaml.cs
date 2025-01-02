using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.ViewModels.Employees;
using System.Windows.Controls;

namespace Employee_And_Company_Management.Views.Controls.Employees
{
    /// <summary>
    /// Interaction logic for EmploymentsControl.xaml
    /// </summary>
    public partial class EmploymentsControl : UserControl
    {
        public EmploymentsControl(LoginDTO loginDTO)
        {
            InitializeComponent();
            DataContext = new EmploymentsViewModel(loginDTO);  
        }
    }
}
