using System;
using System.Collections.Generic;

namespace Employee_And_Company_Management.Data.Entities;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CompanyProfileId { get; set; }

    public virtual Company CompanyProfile { get; set; } = null!;

    public virtual ICollection<WorkPlace> WorkPlaces { get; set; } = new List<WorkPlace>();
}
