using Employee_And_Company_Management.ViewModels.Employees;
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
using System.Windows.Shapes;

namespace Employee_And_Company_Management.Views.Windows.Employees
{
    /// <summary>
    /// Interaction logic for SalariesEmployeeWindow.xaml
    /// </summary>
    public partial class SalariesEmployeeWindow : Window
    {
        public SalariesEmployeeWindow(EmploymentsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
