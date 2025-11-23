using System;
using System.Collections.Generic;

namespace SunniNooriMasjidAPI.Data.Entities;

public partial class Masjidyearlyexpense
{
    public int Id { get; set; }

    public DateTime CollectionDate { get; set; }

    public string Category { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Amount { get; set; }

    public string PaidTo { get; set; } = null!;

    public int? MemberId { get; set; }

    public int? Year { get; set; }

    public virtual Member? Member { get; set; }
}
