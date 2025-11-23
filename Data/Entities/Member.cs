using System;
using System.Collections.Generic;

namespace SunniNooriMasjidAPI.Data.Entities;

public partial class Member
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int RoleId { get; set; }

    public string? FatherName { get; set; }

    public string? MobileNumber { get; set; }

    public string? MemberPic { get; set; }

    public DateTime? JoiningDate { get; set; }

    public int? MohallaId { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<MasjidGullakCollection> MasjidGullakCollectionCreatedByNavigations { get; set; } = new List<MasjidGullakCollection>();

    public virtual ICollection<MasjidGullakCollection> MasjidGullakCollectionUpdatedByNavigations { get; set; } = new List<MasjidGullakCollection>();

    public virtual ICollection<Masjidyearlyexpense> Masjidyearlyexpenses { get; set; } = new List<Masjidyearlyexpense>();

    public virtual Mohalla? Mohalla { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
