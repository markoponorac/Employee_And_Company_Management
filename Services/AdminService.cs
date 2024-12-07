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
    public class AdminService
    {
        public AdminService()
        {
        }

        public async Task UpdateAdmin(Administrator administrator)
        {
            if (administrator == null)
            {
                return;
            }
            using (var _context = new EmployeeAndCompanyManagementContext())
            {
                Person person = await _context.People.FirstOrDefaultAsync(i => i.ProfileId.Equals(administrator.PersonProfileId));
                if (person != null)
                {
                    if (!string.IsNullOrWhiteSpace(administrator.PersonProfile.FirstName))
                    {
                        person.FirstName = administrator.PersonProfile.FirstName;
                    }
                    if (!string.IsNullOrWhiteSpace(administrator.PersonProfile.LastName))
                    {
                        person.LastName = administrator.PersonProfile.LastName;
                    }
                }
                await _context.SaveChangesAsync();

            }
        }


    }
}
