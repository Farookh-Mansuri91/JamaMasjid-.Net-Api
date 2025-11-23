using System;
using System.Collections.Generic;

namespace SunniNooriMasjidAPI.Data.Entities;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public string RoleType { get; set; } = null!;

    public virtual ICollection<Masjidimam> Masjidimams { get; set; } = new List<Masjidimam>();

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}
