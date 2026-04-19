using System.Text.Json.Serialization;

namespace shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserRole
{
    Citizen,
    Admin
}

public record UserDto(int Id, string Dni, string FullName, int Points, UserRole Role);
public record UserCreateDto(string Dni, string FullName, UserRole Role = UserRole.Citizen);
public record UserUpdateDto(string Dni, string FullName, int Points, UserRole Role);
