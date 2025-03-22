using System;
using System.Collections.Generic;

namespace SpacesReservation.API.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Profile? Profile { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<Space> Spaces { get; set; } = new List<Space>();
}
