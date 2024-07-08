using API.Services.Autre;

namespace API.Models;

public partial class Admin
{
    public string Idadmin { get; set; } = null!;

    public string? Login { get; set; }
    public string? Password{get;set;}
}
