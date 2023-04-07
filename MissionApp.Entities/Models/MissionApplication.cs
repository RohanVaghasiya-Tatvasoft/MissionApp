using System;
using System.Collections.Generic;

namespace MissionApp.Entities.Models;

public partial class MissionApplication
{
    public int MissionApplicationId { get; set; }

    public int MissionId { get; set; }

    public int UserId { get; set; }

    public DateTime? AppliedAt { get; set; }

    public string ApprovalStatus { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Mission Mission { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
