using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Models;

public partial class Etapecoureur
{
    public string Idetapecoureur { get; set; } = null!;

    public string? Idetape { get; set; }

    public string? Idcoureur { get; set; }

    [JsonIgnore]
    public virtual Coureur? IdcoureurNavigation { get; set; }
    [JsonIgnore]
    public virtual Etape? IdetapeNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<Resultat> Resultats { get; set; } = [];
}
