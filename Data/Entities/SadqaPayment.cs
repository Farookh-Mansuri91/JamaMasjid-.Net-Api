using System;
using System.Collections.Generic;

namespace SunniNooriMasjidAPI.Data.Entities;

public partial class SadqaPayment
{
    public int Id { get; set; }

    public int? MemberId { get; set; }

    public string Month { get; set; } = null!;

    public int Year { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual SadqaMembersPayment? Member { get; set; }
}
