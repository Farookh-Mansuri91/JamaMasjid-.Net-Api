using System;
using System.Collections.Generic;

namespace SunniNooriMasjidAPI.Data.Entities;

public partial class Sadqamember
{
    public int MemberId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? FatherName { get; set; }

    public string? Mohalla { get; set; }

    public string? MobileNumber { get; set; }

    public decimal? Amount { get; set; }

    public string? Caste { get; set; }

    public DateTime? PaymentDate { get; set; }

    public int? AddedBy { get; set; }

    public virtual Member? AddedByNavigation { get; set; }
}
