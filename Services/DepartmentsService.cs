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
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    return context.Departments.Where(i => i.CompanyProfileId.Equals(companyId)).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<Department>();
            }
        }


        public async Task<bool> AddDepartment(Department department)
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    Department tempDep = await context.Departments.FirstOrDefaultAsync(i => i.CompanyProfileId.Equals(department.CompanyProfileId) && i.Name.Equals(department.Name));
                    if (tempDep != null)
                    {
                        return false;
                    }
                    context.Departments.Add(department);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public async Task<bool> DeleteDepartment(int departmentID)
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    Department department = await context.Departments.FirstOrDefaultAsync(i => i.Id.Equals(departmentID));
                    if (department != null)
                    {
                        department.IsDeleted = true;
                        await context.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> RestoreDepartment(int departmentID)
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    Department department = await context.Departments.FirstOrDefaultAsync(i => i.Id.Equals(departmentID));
                    if (department != null)
                    {
                        department.IsDeleted = false;
                        await context.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
