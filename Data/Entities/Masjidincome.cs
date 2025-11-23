using System;
using System.Collections.Generic;

namespace SunniNooriMasjidAPI.Data.Entities;

public partial class Masjidincome
{
    public int Id { get; set; }

    public int? VillageMemberId { get; set; }

    public int Year { get; set; }

    public decimal MasjidAmount { get; set; }

    public decimal QabristanAmount { get; set; }

    public decimal MasjidProgamAmount { get; set; }

    public DateTime PaymentDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual VillageMembersPayment? VillageMember { get; set; }
}
