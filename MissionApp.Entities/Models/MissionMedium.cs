using System;
using System.Collections.Generic;

namespace MissionApp.Entities.Models;

public partial class MissionMedium
{
    public int MissionMediaId { get; set; }

    public int MissionId { get; set; }

    public string? MediaName { get; set; }

    public string? MediaType { get; set; }

    public string? MediaPath { get; set; }

    public bool Defaults { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Mission Mission { get; set; } = null!;
}
