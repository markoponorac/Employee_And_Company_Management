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

        public async Task<bool> AddQualification(QualificationLevel qualification)
        {
            using (var context = new EmployeeAndCompanyManagementContext())
            {
                if (qualification != null)
                {
                    QualificationLevel temp = await context.QualificationLevels.FirstOrDefaultAsync(i => i.Title.Equals(qualification.Title));
                    if (temp != null)
                    {
                        return false;
                    }
                    context.QualificationLevels.Add(qualification);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }
    }
}
