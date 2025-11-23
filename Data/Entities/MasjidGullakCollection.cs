using System;
using System.Collections.Generic;

namespace SunniNooriMasjidAPI.Data.Entities;

public partial class MasjidGullakCollection
{
    public int Id { get; set; }

    public DateTime CollectionDate { get; set; }

    public decimal Amount { get; set; }

    public string? Remarks { get; set; }

    public int VillageId { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }

    public virtual Member CreatedByNavigation { get; set; } = null!;

    public virtual Member UpdatedByNavigation { get; set; } = null!;

    public virtual Village Village { get; set; } = null!;
}
