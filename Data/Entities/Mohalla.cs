using System;
using System.Collections.Generic;

namespace SunniNooriMasjidAPI.Data.Entities;

public partial class Mohalla
{
    public int MohallaId { get; set; }

    public string MohallaName { get; set; } = null!;

    public int? Population { get; set; }

    public int? VillageId { get; set; }

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();

    public virtual Village? Village { get; set; }
}
