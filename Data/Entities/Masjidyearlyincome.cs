using System;
using System.Collections.Generic;

namespace SunniNooriMasjidAPI.Data.Entities;

public partial class Masjidyearlyincome
{
    public int IncomeId { get; set; }

    public decimal MasjidIncome { get; set; }

    public decimal QabristaanIncome { get; set; }

    public decimal MasjidProgramIncome { get; set; }

    public DateTime PaymentDate { get; set; }

    public int? MohallaId { get; set; }

    public int? VillageMemberId { get; set; }

    public int? UpdatedBy { get; set; }

    public int? CreatedBy { get; set; }

    public string? Remarks { get; set; }

    public virtual Member? CreatedByNavigation { get; set; }

    public virtual Mohalla? Mohalla { get; set; }

    public virtual Member? UpdatedByNavigation { get; set; }

    public virtual Villagemember? VillageMember { get; set; }
}
