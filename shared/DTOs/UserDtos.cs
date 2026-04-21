using shared.Enums;
using System.Text.Json.Serialization;

namespace shared;

public record UserDto(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("dni")] string Dni,
    [property: JsonPropertyName("fullName")] string FullName,
    [property: JsonPropertyName("points")] int Points,
    [property: JsonPropertyName("role")] UserRoleEnums Role
)
{
    public override string ToString() => FullName;
}
public record UserCreateDto(string Dni, string FullName, UserRoleEnums Role = UserRoleEnums.Citizen);
public record UserUpdateDto(string Dni, string FullName, int Points, UserRoleEnums Role);