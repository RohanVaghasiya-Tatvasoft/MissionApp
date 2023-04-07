using System;
using System.Collections.Generic;

namespace MissionApp.Entities.Models;

public partial class Timesheet
{
    public int TimesheetId { get; set; }

    public int UserId { get; set; }

    public int MissionId { get; set; }

    public int? Time { get; set; }

    public int? Action { get; set; }

    public DateTime? DateVolunteered { get; set; }

    public string? Notes { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Mission Mission { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
