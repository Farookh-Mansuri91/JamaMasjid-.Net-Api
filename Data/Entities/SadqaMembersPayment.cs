using System;
using System.Collections.Generic;

namespace SunniNooriMasjidAPI.Data.Entities;

public partial class SadqaMembersPayment
{
    public int Id { get; set; }

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

    public bool? IsActive { get; set; }

    public virtual ICollection<SadqaPayment> SadqaPayments { get; set; } = new List<SadqaPayment>();
}
