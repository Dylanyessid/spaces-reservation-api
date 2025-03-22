using System;
using System.Collections.Generic;

namespace SpacesReservation.API.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int SpaceId { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public virtual Space Space { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
