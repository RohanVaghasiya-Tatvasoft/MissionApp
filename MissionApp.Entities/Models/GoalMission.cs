using System;
using System.Collections.Generic;

namespace MissionApp.Entities.Models;

public partial class GoalMission
{
    public int GoalMissionId { get; set; }

    public int MissionId { get; set; }

    public string? GoalObjectiveText { get; set; }

    public int? GoalValue { get; set; }

    public int? TotalValue { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Mission Mission { get; set; } = null!;
}
