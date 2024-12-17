using Employee_And_Company_Management.Data;
using Employee_And_Company_Management.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_And_Company_Management.Services
{
    public class DepartmentsService
    {
        public DepartmentsService() { }

        public async Task<List<Department>> getDepartmenentsForCompany(int companyId)
        {
            using(var context = new EmployeeAndCompanyManagementContext())
            {
                return context.Departments.Where(i => i.Id.Equals(companyId)).ToList();
            }
        }
    }
}
