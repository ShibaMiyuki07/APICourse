using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Resultatspenalite
{
    public string Idresultatpenalite { get; set; } = null!;

    public string? Idresultat { get; set; }

    public TimeOnly? Heuredepart { get; set; }

    public TimeOnly? Heurearrive { get; set; }

    public virtual Resultat? IdresultatNavigation { get; set; }
}
