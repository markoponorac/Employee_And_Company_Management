using Employee_And_Company_Management.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_And_Company_Management.Services
{
    class SalariesService
    {
        public SalariesService()
        {
        }


        public async Task<List<Salary>> GetSalariesByEmployeeAndCompany(int employeeId, int companyId)
        {
            try
            {
                using(var context = new EmployeeAndCompanyManagementContext())
                {
                    return context.Salaries.Where(i => i.Employment.EmployeePersonProfileId == employeeId && i.Employment.CompanyProfileId == companyId).ToList();
                }
            }
            catch (Exception e)
            {
                return new List<Salary>();
            }
        }


        public async Task<List<Salary>> GetSalariesByEmployment(Employment employment)
        {
            try
            {
                using(var context = new EmployeeAndCompanyManagementContext())
                {
                    return context.Salaries.Where(i => i.Employment.Equals(employment)).ToList();
                }
            }
            catch (Exception e)
            {
                return new List<Salary>();
            }
        }

        public async Task<bool> AddSalaryForEmployeeAndCompany(Salary salary, int employeeId, int companyId)
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    Employment employment = context.Employments.FirstOrDefault(i => i.CompanyProfileId == companyId && i.EmployeePersonProfileId == employeeId && i.EmployedTo == null);
                    if (employment != null)
                    {
                        bool salaryExists = context.Salaries
                       .Any(s => s.EmploymentCompanyProfileId == companyId &&
                                 s.EmploymentEmployeePersonProfileId == employeeId &&
                                 s.ForMonth == salary.ForMonth &&
                                 s.ForYear == salary.ForYear);

                        if (salaryExists)
                        {
                            return false;
                        }
                        salary.Employment = employment;
                        context.Salaries.Add(salary);
                        await context.SaveChangesAsync();
                        return true;
                    }
                    else
                    {

                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
