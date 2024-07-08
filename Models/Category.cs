using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Category
{
    public string Idcategorie { get; set; } = null!;

    public string? Categorie { get; set; }

    public virtual ICollection<Coureurcategory> Coureurcategories { get; set; } = [];
}
