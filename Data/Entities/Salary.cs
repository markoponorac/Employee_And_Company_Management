using System;
using System.Collections.Generic;

namespace Employee_And_Company_Management.Data.Entities;

public partial class Salary
{
    public int Id { get; set; }

    public decimal Amount { get; set; }

    public DateOnly PaymentDate { get; set; }

    public int ForMonth { get; set; }

    public int ForYear { get; set; }

    public DateOnly EmploymentEmployedFrom { get; set; }

    public int EmploymentWorkPlaceId { get; set; }

    public int EmploymentCompanyProfileId { get; set; }

    public int EmploymentEmployeePersonProfileId { get; set; }

    public virtual Employment Employment { get; set; } = null!;
}
