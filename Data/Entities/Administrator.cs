using System;
using System.Collections.Generic;

namespace Employee_And_Company_Management.Data.Entities;

public partial class Administrator
{
    public int PersonProfileId { get; set; }

    public virtual Person PersonProfile { get; set; } = null!;
}
