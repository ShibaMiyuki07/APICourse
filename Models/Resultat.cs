using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Resultat
{
    public string Idresultat { get; set; } = null!;

    public string? Idetapecoureur { get; set; }

    public TimeOnly? Heuredepart { get; set; }

    public TimeOnly? Heurearrive { get; set; }

    public virtual Etapecoureur? IdetapecoureurNavigation { get; set; }

    public virtual ICollection<Resultatspenalite> Resultatspenalites { get; set; } = [];
}
