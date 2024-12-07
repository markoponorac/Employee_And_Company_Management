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
    public class QualificationsServis
    {
        public QualificationsServis()
        {
        }

        public async Task<List<QualificationLevel>> GetQualificationLevels()
        {
            using(var context = new EmployeeAndCompanyManagementContext())
            {
                return await context.QualificationLevels.ToListAsync();
            }
        }
    }
}
