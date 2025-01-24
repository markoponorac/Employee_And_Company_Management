using Employee_And_Company_Management.Data.Entities;
using Employee_And_Company_Management.Helpers.Constants;
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

        public async Task<bool> AddEmployment(Employment employment)
        {
            try
            {
                using (var contex = new EmployeeAndCompanyManagementContext())
                {
                    contex.Entry(employment.EmployeePersonProfile).State = EntityState.Unchanged;
                    contex.Entry(employment.CompanyProfile).State = EntityState.Unchanged;
                    contex.Entry(employment.WorkPlace).State = EntityState.Unchanged;
                    Employee employee = await contex.Employees.FirstOrDefaultAsync(i => i.PersonProfileId == employment.EmployeePersonProfile.PersonProfileId);
                    if (employee != null)
                    {
                        employee.IsEmployed = true;
                    }
                    contex.Employments.Add(employment);
                    await contex.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<string> EndEmployment(Employee employee, DateTime date)
        {
            try
            {
                using (var contex = new EmployeeAndCompanyManagementContext())
                {
                    Employment employment = await contex.Employments.FirstOrDefaultAsync(i => i.EmployeePersonProfileId == employee.PersonProfileId && i.EmployedTo == null);

                    DateOnly temp = DateOnly.FromDateTime(date); ;

                    if (employment.EmployedFrom >= temp)
                    {
                        return ServiceOperationStatus.DISMIS_BEFORE;
                    }

                    employment.EmployedTo = temp;


                    Employee tempEmployee = await contex.Employees.FirstOrDefaultAsync(i => i.PersonProfileId == employee.PersonProfileId);
                    if (tempEmployee != null)
                    {
                        tempEmployee.IsEmployed = false;
                    }

                    await contex.SaveChangesAsync();
                    return ServiceOperationStatus.SUCCESS;
                }
            }
            catch (Exception ex)
            {
                return ServiceOperationStatus.ERROR;
            }
        }


        public async Task<List<Employment>> GetEmploymentsForEmployee(int employeeId)
        {
            try
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
            catch (Exception ex)
            {
                return new List<Employment>();
            }
        }


        public async Task<List<Employment>> GetEmploymentsForEmployeeInCompany(int employeeId, int companyId)
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    return await context.Employments
                        .Include(e => e.WorkPlace)
                        .ThenInclude(wp => wp.Department)
                        .Include(e => e.CompanyProfile)
                        .Where(e => e.EmployeePersonProfileId == employeeId && e.CompanyProfile.ProfileId == companyId)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return new List<Employment>();
            }
        }

    }
}
