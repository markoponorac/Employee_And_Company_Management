using Employee_And_Company_Management.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_And_Company_Management.Services
{
    public class WorkPlacesService
    {
        public WorkPlacesService()
        {
        }

        public async Task<List<WorkPlace>> GetWorkPlacesInDepartment(int departmentID)
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    return await context.WorkPlaces.Where(i => i.DepartmentId == departmentID).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return new List<WorkPlace>();
            }
        }


        public async Task<List<WorkPlace>> GetFreeWorkPlacesInDepartment(int departmentID)
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    return await context.WorkPlaces
                     .Where(workPlace =>
                         workPlace.DepartmentId == departmentID &&
                         !context.Employments.Any(employment =>
                             employment.WorkPlaceId == workPlace.Id && employment.EmployedTo == null))
                     .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return new List<WorkPlace>();
            }
        }

        public async Task<bool> AddWorkPlace(WorkPlace workPlace)
        {
            try
            {
                using (var contex = new EmployeeAndCompanyManagementContext())
                {

                    contex.Entry(workPlace.Department).State = EntityState.Unchanged;
                    contex.WorkPlaces.Add(workPlace);
                    await contex.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<bool> DeleteWorkPlace(int workPlaceId)
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    WorkPlace workPlace = await context.WorkPlaces.FirstOrDefaultAsync(i => i.Id.Equals(workPlaceId));
                    if (workPlace != null)
                    {
                        workPlace.IsDeleted = true;
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

        public async Task<bool> RestoreWorkPlace(int workPlaceId)
        {
            try
            {
                using (var context = new EmployeeAndCompanyManagementContext())
                {
                    WorkPlace workPlace = await context.WorkPlaces.FirstOrDefaultAsync(i => i.Id.Equals(workPlaceId));
                    if (workPlace != null)
                    {
                        workPlace.IsDeleted = false;
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
    }
}
