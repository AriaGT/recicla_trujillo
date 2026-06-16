using shared.Enums;

namespace api.Models;

public class User
{
    public int Id { get; set; }
    public string Dni { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public UserRoleEnums Role { get; set; } = UserRoleEnums.Citizen;
}
