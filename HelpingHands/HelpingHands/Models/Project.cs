using System;
using System.Collections.Generic;

namespace HelpingHands.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string Image { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? TargetAmount { get; set; }

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();
}
