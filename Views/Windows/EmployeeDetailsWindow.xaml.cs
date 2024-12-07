using Employee_And_Company_Management.Data.Entities;
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

namespace Employee_And_Company_Management.Views.Windows
{
    /// <summary>
    /// Interaction logic for EmployeeDetailsWindow.xaml
    /// </summary>
    public partial class EmployeeDetailsWindow : Window
    {
        public EmployeeDetailsWindow(Employee employee)
        {
            InitializeComponent();
            FirstNameTextBlock.Text = employee.PersonProfile.FirstName;
            LastNameTextBlock.Text = employee.PersonProfile.LastName;
            UsernameTextBlock.Text = employee.PersonProfile.Profile.Username;
            DateOfBirthTextBlock.Text = employee.DateOfBirth.ToString();
            QualificationTextBlock.Text = employee.QualificationLevel.Title;
            JmbTextBlock.Text = employee.PersonProfile.Jmb;
        }
    }
}
