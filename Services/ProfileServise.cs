using Employee_And_Company_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_And_Company_Management.Services
{
    public class ProfileServise
    {
        public ProfileServise()
        {
        }

        public void ChangeLanguage(int id, string language)
        {
            using (var _context = new EmployeeAndCompanyManagementContext())
            {
                var profile = _context.Profiles.FirstOrDefault(i => i.Id.Equals(id));
                if(profile != null)
                {
                    profile.Language = language;
                    _context.SaveChanges();
                }
            }
        }

        public void ChangeTheme(int id, string theme)
        {
            using (var _context = new EmployeeAndCompanyManagementContext())
            {
                var profile = _context.Profiles.FirstOrDefault(i => i.Id.Equals(id));
                if (profile != null)
                {
                    profile.Theme = theme;
                    _context.SaveChanges();
                }
            }
        }
    }
}
