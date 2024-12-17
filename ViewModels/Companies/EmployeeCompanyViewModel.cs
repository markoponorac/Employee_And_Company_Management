using Employee_And_Company_Management.Data.Entities;
using Employee_And_Company_Management.Models;
using Employee_And_Company_Management.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Employee_And_Company_Management.ViewModels.Companies
{
    class EmployeeCompanyViewModel :BaseViewModel
    {
        private readonly EmployeeService _employeeService;
        public ObservableCollection<Employee> CurrentlyEmployed { get; set; }
        public ObservableCollection<Employee> FormerEmployees { get; set; }

        public ICommand ViewDetailsCommand { get; set; }

        private LoginDTO loginDTO;

        public EmployeeCompanyViewModel(LoginDTO loginDTO)
        {
            this.loginDTO = loginDTO;
        }
    }
}
