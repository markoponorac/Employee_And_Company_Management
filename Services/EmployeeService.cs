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
    public class EmployeeService
    {
        public EmployeeService()
        {
        }

        public async Task<List<Employee>> getEmployees()
        {
            using (var context = new EmployeeAndCompanyManagementContext())
            {
                return await context.Employees.Include(i => i.PersonProfile).ThenInclude(p => p.Profile).Include(r => r.QualificationLevel).ToListAsync();
            }
        }

        public async Task ChangeActiveStatus(int employeeId)
        {
            using(var context = new EmployeeAndCompanyManagementContext())
            {
                Employee employee = await context.Employees.Include(i => i.PersonProfile).ThenInclude(p => p.Profile).FirstOrDefaultAsync(r => r.PersonProfileId.Equals(employeeId));
                if(employee != null)
                {
                    employee.PersonProfile.Profile.IsActive = !employee.PersonProfile.Profile.IsActive;
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task DeleteEmployee(int employeeId)
        {
            using (var context = new EmployeeAndCompanyManagementContext())
            {
                Employee employee = await context.Employees.Include(i => i.PersonProfile).ThenInclude(p => p.Profile).FirstOrDefaultAsync(r => r.PersonProfileId.Equals(employeeId));
                if (employee != null)
                {
                    employee.PersonProfile.Profile.IsDeleted = true;
                    await context.SaveChangesAsync();
                }
            }
        }
        
        public async Task<bool> AddEmployee(Employee employee)
        {
            using (var context = new EmployeeAndCompanyManagementContext())
            {
                if (employee != null)
                {
                    Employee temp= await context.Employees.FirstOrDefaultAsync(i => i.PersonProfile.Jmb.Equals(employee.PersonProfile.Jmb));
                    if (temp != null)
                    {
                        return false;
                    }
                    context.Employees.Add(employee);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }
    }
}
