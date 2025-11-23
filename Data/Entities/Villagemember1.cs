using System;
using System.Collections.Generic;

namespace SunniNooriMasjidAPI.Data.Entities;

public partial class Villagemember1
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? FatherName { get; set; }

    public int? MohallaId { get; set; }

    public string? MobileNumber { get; set; }

    public decimal? Amount { get; set; }

    public string? Caste { get; set; }

    public DateTime? PaymentDate { get; set; }

    public int? MemberId { get; set; }

    public virtual ICollection<Masjidyearlyincome> Masjidyearlyincomes { get; set; } = new List<Masjidyearlyincome>();

    public virtual Member? Member { get; set; }

    public virtual Mohalla? Mohalla { get; set; }
}
