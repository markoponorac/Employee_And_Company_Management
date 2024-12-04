using System;
using System.Collections.Generic;

namespace Employee_And_Company_Management.Data.Entities;

public partial class Person
{
    public int ProfileId { get; set; }

    public string Jmb { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual Administrator? Administrator { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Profile Profile { get; set; } = null!;
}
