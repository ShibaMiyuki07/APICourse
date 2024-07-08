using API.Services.Autre;
using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Equipe
{
    public string Idequipe { get; set; } = null!;

    public string? Nomequipe { get; set; }

    public string? Login { get; set; }

    public string? Password {get;set; }

    public virtual ICollection<Coureur> Coureurs { get; set; } = [];
}
