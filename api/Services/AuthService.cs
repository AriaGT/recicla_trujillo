using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using shared;
using shared.Enums;

namespace api.Services;

public class AuthService
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<AuthSessionDto?> LoginByDni(string dni)
    {
        var normalizedDni = (dni ?? string.Empty).Trim();
        if (string.IsNullOrWhiteSpace(normalizedDni))
            return null;

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Dni == normalizedDni);
        if (user == null)
            return null;

        return new AuthSessionDto(user.Id, user.FullName, user.Role);
    }

    public async Task<UserDto> RegisterCitizen(AuthRegisterDto dto)
    {
        var dni = (dto.Dni ?? string.Empty).Trim();
        var fullName = (dto.FullName ?? string.Empty).Trim();

        if (string.IsNullOrWhiteSpace(dni))
            throw new InvalidOperationException("El DNI es obligatorio");

        if (string.IsNullOrWhiteSpace(fullName))
            throw new InvalidOperationException("El nombre completo es obligatorio");

        if (await _context.Users.AnyAsync(u => u.Dni == dni))
            throw new InvalidOperationException("Ya existe un usuario con ese DNI");

        var user = new User
        {
            Dni = dni,
            FullName = fullName,
            Role = UserRoleEnums.Citizen
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new UserDto(user.Id, user.Dni, user.FullName, user.Points, user.Role);
    }
}
