
using Employee_And_Company_Management.Data.Entities;
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

        public async Task<bool> ChangeLanguage(int id, string language)
        {
            try
            {
                using (var _context = new EmployeeAndCompanyManagementContext())
                {
                    var profile = _context.Profiles.FirstOrDefault(i => i.Id.Equals(id));
                    if (profile != null)
                    {
                        profile.Language = language;
                        await _context.SaveChangesAsync();
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

        public async Task<bool> ChangeTheme(int id, string theme)
        {
            try
            {
                using (var _context = new EmployeeAndCompanyManagementContext())
                {
                    var profile = _context.Profiles.FirstOrDefault(i => i.Id.Equals(id));
                    if (profile != null)
                    {
                        profile.Theme = theme;
                        await _context.SaveChangesAsync();
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

        public async Task<bool> ChangePassword(int id, string oldPassword, string newPassword)
        {
            try
            {
                using (var _context = new EmployeeAndCompanyManagementContext())
                {
                    var profile = _context.Profiles.FirstOrDefault(p => p.Id.Equals(id));
                    if (profile != null)
                    {
                        if (!profile.Password.Equals(oldPassword) || oldPassword.Equals(newPassword))
                        {
                            return false;
                        }
                        profile.Password = newPassword;
                        await _context.SaveChangesAsync();
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
