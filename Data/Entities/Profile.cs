using System;
using System.Collections.Generic;

namespace Employee_And_Company_Management.Data.Entities;

public partial class Profile
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Theme { get; set; } = null!;

    public string Language { get; set; } = null!;

    public virtual Company? Company { get; set; }

    public virtual Person? Person { get; set; }

    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
