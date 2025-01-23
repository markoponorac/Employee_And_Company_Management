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
            UsernameTextBox.Text = employee.PersonProfile.Profile.Username;
            FirstNameTextBox.Text = employee.PersonProfile.FirstName;
            LastNameTextBox.Text = employee.PersonProfile.LastName;
            DateOfBirthTextBox.Text = employee.DateOfBirth.ToString("dd.MM.yyyy.");
            JmbTextBox.Text = employee.PersonProfile.Jmb;
            QualificationTextBox.Text = employee.QualificationLevel.Title;
        }
    }
}
