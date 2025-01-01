using Employee_And_Company_Management.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Employee_And_Company_Management.Services
{
    public class EmploymentService
    {
        public EmploymentService()
        {
        }

        public async Task AddEmployment(Employment employment)
        {
            using(var contex = new EmployeeAndCompanyManagementContext())
            {
                contex.Entry(employment.EmployeePersonProfile).State = EntityState.Unchanged;
                contex.Entry(employment.CompanyProfile).State = EntityState.Unchanged;
                contex.Entry(employment.WorkPlace).State = EntityState.Unchanged;
                Employee employee = await contex.Employees.FirstOrDefaultAsync(i => i.PersonProfileId == employment.EmployeePersonProfile.PersonProfileId);
                if (employee != null) { 
                    employee.IsEmployed = true;
                }
                contex.Employments.Add(employment);
                await contex.SaveChangesAsync();
            }
        }

        public async Task EndEmployment(Employee employee)
        {
            using (var contex = new EmployeeAndCompanyManagementContext())
            {
                Employment employment = await contex.Employments.FirstOrDefaultAsync(i => i.EmployeePersonProfileId == employee.PersonProfileId && i.EmployedTo == null);
               
                employment.EmployedTo = DateOnly.FromDateTime(DateTime.Now);

                Employee tempEmployee = await contex.Employees.FirstOrDefaultAsync(i => i.PersonProfileId == employee.PersonProfileId);
                if (tempEmployee != null)
                {
                    tempEmployee.IsEmployed = false;
                }
                
                await contex.SaveChangesAsync();
            }
        }


        public async Task<List<Employment>> GetEmploymentsForEmployee(int employeeId)
        {
            using (var context = new EmployeeAndCompanyManagementContext())
            {
                return await context.Employments
                    .Include(e => e.WorkPlace) 
                    .ThenInclude(wp => wp.Department)
                    .Include(e => e.CompanyProfile) 
                    .Where(e => e.EmployeePersonProfileId == employeeId) 
                    .ToListAsync(); 
            }
        }


    }
}
