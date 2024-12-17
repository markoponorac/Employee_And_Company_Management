using Employee_And_Company_Management.Data;
using Employee_And_Company_Management.Data.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Department>> GetDepartmenentsForCompany(int companyId)
        {
            using(var context = new EmployeeAndCompanyManagementContext())
            {
                return context.Departments.Where(i => i.CompanyProfileId.Equals(companyId)).ToList();
            }
        }


        public async Task<bool> AddDepartment(Department department)
        {
            using(var context = new EmployeeAndCompanyManagementContext())
            {
                Department tempDep = await context.Departments.FirstOrDefaultAsync(i => i.CompanyProfileId.Equals(department.CompanyProfileId) && i.Name.Equals(department.Name));
                if(tempDep != null)
                {
                    return false;
                }
                context.Departments.Add(department);
                await context.SaveChangesAsync();
                return true;
            }
        }


        public async Task DeleteDepartment(int departmentID)
        {
            using (var context = new EmployeeAndCompanyManagementContext())
            {
                Department department = await context.Departments.FirstOrDefaultAsync(i => i.Id.Equals(departmentID));
                if (department != null)
                {
                    department.IsDeleted = true;
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task RestoreDepartment(int departmentID)
        {
            using (var context = new EmployeeAndCompanyManagementContext())
            {
                Department department = await context.Departments.FirstOrDefaultAsync(i => i.Id.Equals(departmentID));
                if (department != null)
                {
                    department.IsDeleted = false;
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
