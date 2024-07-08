using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Models;

public partial class Etape
{
    public string Idetape { get; set; } = null!;

    public string? Nometape { get; set; }

    public double? Longueur { get; set; }

    public int? Nombrecoureur { get; set; }

    public int? Rang { get; set; }

    public DateOnly? Datedepart { get; set; }

    public TimeOnly? Heuredepart { get; set; }

    [JsonIgnore]
    public virtual ICollection<Etapecoureur> Etapecoureurs { get; set; } = [];
}
