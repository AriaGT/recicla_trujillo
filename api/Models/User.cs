using System.Text.Json.Serialization;

namespace api.Models;

public class User
{
    public int Id { get; set; }
    public string Dni { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int Points { get; set; } = 0;
    public shared.UserRole Role { get; set; } = shared.UserRole.Citizen;
}
