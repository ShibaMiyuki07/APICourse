using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Coureurcategory
{
    public string Idcoureurcategorie { get; set; } = null!;

    public string? Idcoureur { get; set; }

    public string? Idcategorie { get; set; }

    public virtual Category? IdcategorieNavigation { get; set; }

    public virtual Coureur? IdcoureurNavigation { get; set; }
}
