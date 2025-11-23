using System;
using System.Collections.Generic;

namespace SunniNooriMasjidAPI.Data.Entities;

public partial class Masjidimam
{
    public int Id { get; set; }

    public string ImamName { get; set; } = null!;

    public string? FatherName { get; set; }

    public DateTime JoinedDate { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public DateTime? LastServingDay { get; set; }

    public string? TotalService { get; set; }

    public decimal Salary { get; set; }

    public string? Image { get; set; }

    public string? ContactNumber { get; set; }

    public string? Education { get; set; }

    public string? Bio { get; set; }

    public string? Vision { get; set; }

    public bool? IsActive { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<Imamhistory> Imamhistories { get; set; } = new List<Imamhistory>();

    public virtual Role Role { get; set; } = null!;
}
