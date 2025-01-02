using Employee_And_Company_Management.Data.Entities;
using Employee_And_Company_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Employee_And_Company_Management.Services
{
    public class CompanyService
    {
        public CompanyService()
        {
        }

        public async Task<List<Company>> GetCompanies()
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    return await context.Companies.Include(i => i.Profile).ToListAsync();
                }
            }
            catch (Exception e)
            {
               return new List<Company>();
            }
        }


        public async Task<Company> GetCompany(int companyId)
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    return await context.Companies.Include(i => i.Profile).FirstOrDefaultAsync(i => i.ProfileId == companyId);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> ChangeActiveStatus(int companyId)
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    Company company = await context.Companies.Include(i => i.Profile).FirstOrDefaultAsync(r => r.ProfileId.Equals(companyId));
                    if (company != null)
                    {
                        company.Profile.IsActive = !company.Profile.IsActive;
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
        public async Task<bool> DeleteCompany(int companyId)
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    Company company = await context.Companies.Include(i => i.Profile).FirstOrDefaultAsync(r => r.ProfileId.Equals(companyId));
                    if (company != null)
                    {
                        company.Profile.IsDeleted = true;
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

        public async Task<bool> AddCompany(Company company)
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    if (company != null)
                    {
                        Company temp = await context.Companies.FirstOrDefaultAsync(i => i.Jib.Equals(company.Jib));
                        if (temp != null)
                        {
                            return false;
                        }
                        context.Companies.Add(company);
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

        public async Task<bool> Update(Company company)
        {
            try
            {
                if (company == null)
                {
                    return false;
                }
                using (var _context = new EmployeeAndCompanyManagementContext())
                {
                    Company tempCompany = await _context.Companies.FirstOrDefaultAsync(i => i.ProfileId.Equals(company.ProfileId));
                    if (tempCompany != null)
                    {
                        if (!string.IsNullOrWhiteSpace(company.Address))
                        {
                            tempCompany.Address = company.Address;
                        }
                    }
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
