using System;
using System.Collections.Generic;

namespace Employee_And_Company_Management.Data.Entities;

public partial class Employee
{
    public DateOnly DateOfBirth { get; set; }

    public bool IsEmployed { get; set; }

    public int QualificationLevelId { get; set; }

    public int PersonProfileId { get; set; }

    public virtual Person PersonProfile { get; set; } = null!;

    public virtual QualificationLevel QualificationLevel { get; set; } = null!;
}
