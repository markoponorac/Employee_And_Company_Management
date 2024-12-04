using System;
using System.Collections.Generic;

namespace Employee_And_Company_Management.Data.Entities;

public partial class Employment
{
    public DateOnly EmployedFrom { get; set; }

    public DateOnly? EmployedTo { get; set; }

    public decimal PriceOfWork { get; set; }

    public int NumberOfDaysOff { get; set; }

    public int WorkPlaceId { get; set; }

    public string EmployeePersonJmb { get; set; } = null!;

    public int CompanyProfileId { get; set; }

    public virtual Company CompanyProfile { get; set; } = null!;

    public virtual ICollection<Salary> Salaries { get; set; } = new List<Salary>();

    public virtual WorkPlace WorkPlace { get; set; } = null!;
}
