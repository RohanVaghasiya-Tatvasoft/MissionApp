using System;
using System.Collections.Generic;

namespace MissionApp.Entities.Models;

public partial class StoryInvite
{
    public int StoryInviteId { get; set; }

    public int StoryId { get; set; }

    public int FromUserId { get; set; }

    public int ToUserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual User FromUser { get; set; } = null!;

    public virtual Story Story { get; set; } = null!;

    public virtual User ToUser { get; set; } = null!;
}
