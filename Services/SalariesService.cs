using Employee_And_Company_Management.Data.Entities;
using Employee_And_Company_Management.Helpers.Constants;
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

        public async Task<string> AddSalaryForEmployeeAndCompany(Salary salary, int employeeId, int companyId)
        {
            //try
            //{
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
                            return ServiceOperationStatus.ALREADY_EXISTS;
                        }

                        DateOnly fromDate = employment.EmployedFrom;

                        int numOfDayes = DateTime.DaysInMonth(salary.ForYear, salary.ForMonth);

                        DateOnly temDate = new DateOnly(salary.ForYear, salary.ForMonth, numOfDayes);

                        if(fromDate > temDate)
                        {
                            return ServiceOperationStatus.SALRY_BEFORE;
                        }


                        
                        salary.Employment = employment;
                        context.Salaries.Add(salary);
                        await context.SaveChangesAsync();
                        return ServiceOperationStatus.SUCCESS;
                    }
                    else
                    {

                        return ServiceOperationStatus.FAILURE;
                    }
                }
            //}
            //catch (Exception e)
            //{
            //    return ServiceOperationStatus.ERROR;
            //}
        }

    }
}
