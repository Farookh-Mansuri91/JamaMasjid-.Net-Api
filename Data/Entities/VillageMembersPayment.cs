using System;
using System.Collections.Generic;

namespace SunniNooriMasjidAPI.Data.Entities;

public partial class VillageMembersPayment
{
    public int MemberId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? FatherName { get; set; }

    public string? MobileNumber { get; set; }

    public int? MohallaId { get; set; }

    public int? VillageId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Masjidincome> Masjidincomes { get; set; } = new List<Masjidincome>();

    public virtual ICollection<SalaryPayment> SalaryPayments { get; set; } = new List<SalaryPayment>();
}
