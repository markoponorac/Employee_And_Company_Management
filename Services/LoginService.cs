
using Employee_And_Company_Management.Data.Entities;
using Employee_And_Company_Management.Helpers.Constants;
using Employee_And_Company_Management.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;


namespace Employee_And_Company_Management.Services
{
    public class LoginService
    {

        public LoginService()
        {
        }

        public async Task<LoginDTO> LoginAsync(string username, string password)
        {
            try
            {
                using (var _context = new EmployeeAndCompanyManagementContext())
                {
                    var profile = _context.Profiles.FirstOrDefault(i => i.Username.Equals(username) && i.Password.Equals(password));
                    if (profile == null)
                    {
                        return new LoginDTO()
                        {
                            Success = false,
                            IsActive = false,
                            IsDeleted = false
                        };
                    }
                    var person = _context.People.FirstOrDefault(i => i.ProfileId.Equals(profile.Id));
                    if (person != null)
                    {
                        var employee = _context.Employees.Include(p => p.QualificationLevel).FirstOrDefault(i => i.PersonProfileId.Equals(person.ProfileId));
                        if (employee != null)
                        {
                            return new LoginDTO()
                            {
                                ProfileId = profile.Id,
                                UserName = profile.Username,
                                Role = RoleConstants.EMPLOYEE,
                                Language = profile.Language,
                                Theme = profile.Theme,
                                Success = true,
                                IsActive = profile.IsActive,
                                IsDeleted = profile.IsDeleted,
                                Firstname = person.FirstName,
                                Lastname = person.LastName,
                                Jmb = person.Jmb,
                                DateOfEstablish = employee.DateOfBirth,
                                Qualification = employee.QualificationLevel.Title
                            };
                        }
                        var admin = _context.Administrators.FirstOrDefault(i => i.PersonProfileId.Equals(person.ProfileId));
                        if (admin != null)
                        {
                            return new LoginDTO()
                            {
                                ProfileId = profile.Id,
                                UserName = profile.Username,
                                Role = RoleConstants.ADMINISTRATOR,
                                Language = profile.Language,
                                Theme = profile.Theme,
                                Success = true,
                                IsActive = profile.IsActive,
                                IsDeleted = profile.IsDeleted,
                                Firstname = person.FirstName,
                                Lastname = person.LastName,
                                Jmb = person.Jmb
                            };
                        }
                        return new LoginDTO()
                        {
                            Success = false
                        };
                    }
                    var company = _context.Companies.FirstOrDefault(i => i.ProfileId.Equals(profile.Id));
                    if (company != null)
                    {
                        return new LoginDTO()
                        {
                            ProfileId = profile.Id,
                            UserName = profile.Username,
                            Role = RoleConstants.COMPANY,
                            Language = profile.Language,
                            Theme = profile.Theme,
                            Success = true,
                            IsActive = profile.IsActive,
                            IsDeleted = profile.IsDeleted,
                            DateOfEstablish = company.DateOfEstablishment,
                            Name = company.Name,
                            Jib = company.Jib,
                            Address = company.Address

                        };
                    }
                    return new LoginDTO()
                    {
                        Success = false,
                        IsActive = false,
                        IsDeleted = false
                    };
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
