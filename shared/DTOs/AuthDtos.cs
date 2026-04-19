namespace shared;

public record AuthLoginDto(string Dni);
public record AuthRegisterDto(string Dni, string FullName);
public record AuthSessionDto(int UserId, string FullName, UserRole Role);
