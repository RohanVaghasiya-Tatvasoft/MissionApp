using System;
using System.Collections.Generic;

namespace MissionApp.Entities.Models;

public partial class MissionDocument
{
    public int MissionDocumentId { get; set; }

    public int MissionId { get; set; }

    public string? DocumentName { get; set; }

    public string? DocumentType { get; set; }

    public string? DocumentPath { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Mission Mission { get; set; } = null!;
}
