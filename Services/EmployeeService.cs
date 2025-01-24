using Employee_And_Company_Management.Data.Entities;
using Employee_And_Company_Management.Helpers.Constants;
using Microsoft.EntityFrameworkCore;

namespace Employee_And_Company_Management.Services
{
    public class EmployeeService
    {
        public EmployeeService()
        {
        }

        public async Task<List<Employee>> getEmployees()
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    return await context.Employees.Include(i => i.PersonProfile).ThenInclude(p => p.Profile).Include(r => r.QualificationLevel).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return new List<Employee>();
            }
        
        }

        public async Task<List<Employee>> GetCurrentlyEmployedInCompany(int companyId)
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    return await context.Employees.Include(e => e.PersonProfile).ThenInclude(pp => pp.Profile).Include(e => e.Employments).
                        Where(e => e.Employments.Any(emp => emp.CompanyProfileId == companyId && emp.EmployedTo == null)).ToListAsync();
                    //return await context.Employments
                    //    .Where(e => e.CompanyProfileId == companyId && e.EmployedTo == null)
                    //    .Include(e => e.EmployeePersonProfile)
                    //        .ThenInclude(emp => emp.PersonProfile)
                    //    .Include(e => e.EmployeePersonProfile.QualificationLevel)
                    //    .Select(e => e.EmployeePersonProfile).Include(e => e.PersonProfile).ThenInclude(e => e.Profile)
                    //    .Distinct()
                    //    .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return new List<Employee>();
            }
        }

        public async Task<List<Employee>> GetFormerEmployeesInCompany(int companyId)
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    return await context.Employees.Include(e => e.PersonProfile).ThenInclude(pp => pp.Profile).Include(e => e.Employments).
                        Where(e => e.Employments.Any(emp => emp.CompanyProfileId == companyId && emp.EmployedTo != null)).ToListAsync();
                    //return await context.Employments
                    //    .Where(e => e.CompanyProfileId == companyId && e.EmployedTo != null)
                    //    .Include(e => e.EmployeePersonProfile)
                    //    .ThenInclude(emp => emp.PersonProfile)
                    //    .Include(e => e.EmployeePersonProfile.QualificationLevel)
                    //    .Select(e => e.EmployeePersonProfile).Include(e => e.PersonProfile).ThenInclude(e => e.Profile)
                    //    .Distinct()
                    //    .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return new List<Employee>();
            }
        }



        public async Task<List<Employee>> GetUnemployedEmployees()
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    return await context.Employees.Include(i => i.PersonProfile).ThenInclude(p => p.Profile).Include(r => r.QualificationLevel).
                        Where(i => i.IsEmployed == false && !i.PersonProfile.Profile.IsDeleted && i.PersonProfile.Profile.IsActive).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return new List<Employee>();
            }
        }

        public async Task<bool> ChangeActiveStatus(int employeeId)
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    Employee employee = await context.Employees.Include(i => i.PersonProfile).ThenInclude(p => p.Profile).FirstOrDefaultAsync(r => r.PersonProfileId.Equals(employeeId));
                    if (employee != null)
                    {
                        employee.PersonProfile.Profile.IsActive = !employee.PersonProfile.Profile.IsActive;
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

        public async Task<bool> DeleteEmployee(int employeeId)
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    Employee employee = await context.Employees.Include(i => i.PersonProfile).ThenInclude(p => p.Profile).FirstOrDefaultAsync(r => r.PersonProfileId.Equals(employeeId));
                    if (employee != null)
                    {
                        employee.PersonProfile.Profile.IsDeleted = true;
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

        public async Task<string> AddEmployee(Employee employee)
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    if (employee != null)
                    {
                        Employee temp = await context.Employees.FirstOrDefaultAsync(i => i.PersonProfile.Jmb.Equals(employee.PersonProfile.Jmb) && !i.PersonProfile.Profile.IsDeleted);
                        if (temp != null)
                        {
                            return ServiceOperationStatus.ALREADY_EXISTS;
                        }
                        context.Employees.Add(employee);
                        await context.SaveChangesAsync();
                        return ServiceOperationStatus.SUCCESS;
                    }
                    return ServiceOperationStatus.FAILURE;
                }
            }
            catch (Exception ex)
            {
                return ServiceOperationStatus.ERROR;
            }
        }


        public async Task<bool> UpdateEmployee(Employee employee)
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    Employee employeeTemp = await context.Employees.Include(p => p.PersonProfile).FirstOrDefaultAsync(i => i.PersonProfileId.Equals(employee.PersonProfileId));
                    if (employeeTemp != null)
                    {
                        employeeTemp.PersonProfile.FirstName = employee.PersonProfile.FirstName;
                        employeeTemp.PersonProfile.LastName = employee.PersonProfile.LastName;
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
