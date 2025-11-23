using System;
using System.Collections.Generic;

namespace SunniNooriMasjidAPI.Data.Entities;

public partial class Village
{
    public int VillageId { get; set; }

    public string VillageName { get; set; } = null!;

    public int? TotalPopulation { get; set; }

    public decimal? AreaSize { get; set; }

    public DateOnly? EstablishedDate { get; set; }

    public virtual ICollection<MasjidGullakCollection> MasjidGullakCollections { get; set; } = new List<MasjidGullakCollection>();

    public virtual ICollection<Mohalla> Mohallas { get; set; } = new List<Mohalla>();
}
