using shared.Enums;

namespace shared;

public record UserDto(int Id, string Dni, string FullName, int Points, UserRoleEnums Role);
public record UserCreateDto(string Dni, string FullName, UserRoleEnums Role = UserRoleEnums.Citizen);
public record UserUpdateDto(string Dni, string FullName, int Points, UserRoleEnums Role);