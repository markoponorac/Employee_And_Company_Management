using System;
using System.Collections.Generic;

namespace Employee_And_Company_Management.Data.Entities;

public partial class WorkPlace
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Employment> Employments { get; set; } = new List<Employment>();

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
