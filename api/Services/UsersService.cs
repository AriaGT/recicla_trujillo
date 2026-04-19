using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using shared;

namespace api.Services;

public class UsersService
{
    private readonly AppDbContext _context;

    public UsersService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserDto>> ListUsers()
    {
        return await _context.Users
            .Select(u => ToDto(u))
            .ToListAsync();
    }

    public async Task<UserDto?> GetUserById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        return user == null ? null : ToDto(user);
    }

    public async Task<UserDto> CreateUser(UserCreateDto dto)
    {
        ValidateUserDto(dto.Dni, dto.FullName);

        if (await _context.Users.AnyAsync(u => u.Dni == dto.Dni))
            throw new InvalidOperationException("Ya existe un usuario con ese DNI");

        var user = new User
        {
            Dni = dto.Dni,
            FullName = dto.FullName,
            Role = dto.Role
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return ToDto(user);
    }

    public async Task<UserDto?> UpdateUser(int id, UserUpdateDto dto)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return null;

        ValidateUserDto(dto.Dni, dto.FullName);

        var dniInUse = await _context.Users.AnyAsync(u => u.Id != id && u.Dni == dto.Dni);
        if (dniInUse)
            throw new InvalidOperationException("Ya existe otro usuario con ese DNI");

        if (dto.Points < 0)
            throw new InvalidOperationException("Los puntos no pueden ser negativos");

        user.Dni = dto.Dni;
        user.FullName = dto.FullName;
        user.Points = dto.Points;
        user.Role = dto.Role;

        await _context.SaveChangesAsync();

        return ToDto(user);
    }

    public async Task<bool> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<UserDto?> GetByDni(string dni)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Dni == dni);
        return user == null ? null : ToDto(user);
    }

    private static void ValidateUserDto(string dni, string fullName)
    {
        if (string.IsNullOrWhiteSpace(dni))
            throw new InvalidOperationException("El DNI es obligatorio");

        if (string.IsNullOrWhiteSpace(fullName))
            throw new InvalidOperationException("El nombre completo es obligatorio");
    }

    private static UserDto ToDto(User user) => new(user.Id, user.Dni, user.FullName, user.Points, user.Role);
}
