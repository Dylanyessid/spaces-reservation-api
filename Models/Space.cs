using System;
using System.Collections.Generic;

namespace SpacesReservation.API.Models;

public partial class Space
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Image { get; set; }

    public string? Description { get; set; }

    public string Location { get; set; } = null!;

    public int Capacity { get; set; }

    public decimal PricePerHour { get; set; }

    public int OwnerId { get; set; }

    public bool IsActive { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual User Owner { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
