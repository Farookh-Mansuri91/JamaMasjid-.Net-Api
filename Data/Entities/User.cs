using System;
using System.Collections.Generic;

namespace SunniNooriMasjidAPI.Data.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? PasswordHash { get; set; }

    public int MemberId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Member Member { get; set; } = null!;
}
