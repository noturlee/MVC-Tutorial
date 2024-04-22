using System;
using System.Collections.Generic;

namespace HelpingHands.Models;

public partial class Donor
{
    public int DonorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();
}
