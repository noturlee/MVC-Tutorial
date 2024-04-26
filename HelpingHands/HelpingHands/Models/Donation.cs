using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HelpingHands.Models;

public partial class Donation
{
    public int DonationId { get; set; }

    public int? DonorId { get; set; }

    public int? ProjectId { get; set; }

    public decimal Amount { get; set; }

    public DateOnly? DonationDate { get; set; }

    public virtual Donor? Donor { get; set; }

    public virtual Project? Project { get; set; }
}

