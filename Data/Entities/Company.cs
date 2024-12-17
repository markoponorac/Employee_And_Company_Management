using System;
using System.Collections.Generic;

namespace Employee_And_Company_Management.Data.Entities;

public partial class Company
{
    public int ProfileId { get; set; }

    public string Jib { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateOnly DateOfEstablishment { get; set; }

    public string Address { get; set; } = null!;

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Employment> Employments { get; set; } = new List<Employment>();

    public virtual Profile Profile { get; set; } = null!;
}
