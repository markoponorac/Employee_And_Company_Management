using System;
using System.Collections.Generic;

namespace Employee_And_Company_Management.Data.Entities;

public partial class QualificationLevel
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string QualificationCode { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
