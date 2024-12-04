using System;
using System.Collections.Generic;

namespace Employee_And_Company_Management.Data.Entities;

public partial class Address
{
    public int Id { get; set; }

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string Number { get; set; } = null!;

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}
