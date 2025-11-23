using System;
using System.Collections.Generic;

namespace SunniNooriMasjidAPI.Data.Entities;

public partial class Masjidgullak
{
    public int Id { get; set; }

    public DateOnly CollectionDate { get; set; }

    public decimal Amount { get; set; }

    public string? Remarks { get; set; }

    public int? VillageId { get; set; }

    public int? MemberId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual Member? Member { get; set; }

    public virtual Village? Village { get; set; }
}
