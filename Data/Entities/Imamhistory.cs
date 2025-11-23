using System;
using System.Collections.Generic;

namespace SunniNooriMasjidAPI.Data.Entities;

public partial class Imamhistory
{
    public int Id { get; set; }

    public int ImamId { get; set; }

    public DateOnly AssignmentDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? MasjidAddress { get; set; }

    public string? City { get; set; }

    public string? RoleDescription { get; set; }

    public decimal? Salary { get; set; }

    public string? Remarks { get; set; }

    public virtual Masjidimam Imam { get; set; } = null!;
}
