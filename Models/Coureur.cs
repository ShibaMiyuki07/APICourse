using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Models;

public partial class Coureur
{
    public string Idcoureur { get; set; } = null!;

    public string? Nomcoureur { get; set; }

    public string? Idequipe { get; set; }

    [JsonIgnore]
    public char? Idgenre { get; set; }

    public DateOnly? Datenaissance { get; set; }

    [JsonIgnore]
    public virtual ICollection<Coureurcategory> Coureurcategories { get; set; } = [];
    [JsonIgnore]
    public virtual ICollection<Etapecoureur> Etapecoureurs { get; set; } = [];
    public virtual Equipe? IdequipeNavigation { get; set; }

    public virtual Genre? IdgenreNavigation { get; set; }
}
