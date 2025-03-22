using System;
using System.Collections.Generic;

namespace SpacesReservation.API.Models;

public partial class Profile
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public int UserId { get; set; }

    public string? LastName { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
