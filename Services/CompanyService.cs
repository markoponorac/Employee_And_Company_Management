﻿using Employee_And_Company_Management.Data.Entities;
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
            using (var context = new EmployeeAndCompanyManagementContext())
            {
                return await context.Companies.Include(i => i.Profile).ToListAsync();
            }
        }

        public async Task ChangeActiveStatus(int companyId)
        {
            using (var context = new EmployeeAndCompanyManagementContext())
            {
                Company company = await context.Companies.Include(i => i.Profile).FirstOrDefaultAsync(r => r.ProfileId.Equals(companyId));
                if (company != null)
                {
                    company.Profile.IsActive = !company.Profile.IsActive;
                    await context.SaveChangesAsync();
                }
            }
        }
        public async Task DeleteCompany(int companyId)
        {
            using (var context = new EmployeeAndCompanyManagementContext())
            {
                Company company = await context.Companies.Include(i => i.Profile).FirstOrDefaultAsync(r => r.ProfileId.Equals(companyId));
                if (company != null)
                {
                    company.Profile.IsDeleted = true;
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<bool> AddCompany(Company company)
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

    }
}
