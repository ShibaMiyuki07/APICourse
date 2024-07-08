using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Genre
{
    public char Idgenre { get; set; }

    public string? Genre1 { get; set; }

    public virtual ICollection<Coureur> Coureurs { get; set; } = new List<Coureur>();
}
