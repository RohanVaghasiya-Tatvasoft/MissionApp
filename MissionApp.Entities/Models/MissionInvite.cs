using System;
using System.Collections.Generic;

namespace MissionApp.Entities.Models;

public partial class MissionInvite
{
    public int MissionInviteId { get; set; }

    public int MissionId { get; set; }

    public int FromUserId { get; set; }

    public int ToUserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual User FromUser { get; set; } = null!;

    public virtual Mission Mission { get; set; } = null!;

    public virtual User ToUser { get; set; } = null!;
}
