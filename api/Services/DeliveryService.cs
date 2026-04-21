using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using shared;
using shared.Enums;

namespace api.Services;

public class DeliveryService
{
    private readonly AppDbContext _context;
    private readonly PointsService _pointsService;

    public DeliveryService(AppDbContext context, PointsService pointsService)
    {
        _context = context;
        _pointsService = pointsService;
    }

    public async Task<List<DeliveryDto>> ListDeliveries()
    {
        return await _context.Deliveries
            .Include(d => d.User)
            .AsNoTracking()
            .Select(d => new DeliveryDto(
                d.Id,
                d.UserId,
                new UserDto(d.User.Id, d.User.Dni, d.User.FullName, d.User.Points, d.User.Role),
                d.WasteType,
                d.QuantityKg,
                d.PointsEarned,
                d.CreatedAt))
            .ToListAsync();
    }

    public async Task<DeliveryDto?> GetDeliveryById(int id)
    {
        var delivery = await _context.Deliveries
            .Include(d => d.User)
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == id);

        return delivery == null
            ? null
            : new DeliveryDto(
                delivery.Id,
                delivery.UserId,
                new UserDto(delivery.User.Id, delivery.User.Dni, delivery.User.FullName, delivery.User.Points, delivery.User.Role),
                delivery.WasteType,
                delivery.QuantityKg,
                delivery.PointsEarned,
                delivery.CreatedAt);
    }

    public async Task<DeliveryDto> RegisterDelivery(DeliveryCreateDto dto)
    {
        var user = await _context.Users.FindAsync(dto.UserId);
        if (user == null)
            throw new InvalidOperationException("Usuario no encontrado");

        var wasteType = dto.WasteType;
        var points = _pointsService.CalculatePoints(wasteType.ToString(), dto.QuantityKg);

        var delivery = new Delivery
        {
            UserId = dto.UserId,
            WasteType = wasteType,
            QuantityKg = dto.QuantityKg,
            PointsEarned = points
        };

        user.Points += points;

        _context.Deliveries.Add(delivery);
        await _context.SaveChangesAsync();

        return new DeliveryDto(
            delivery.Id,
            delivery.UserId,
            new UserDto(user.Id, user.Dni, user.FullName, user.Points, user.Role),
            delivery.WasteType,
            delivery.QuantityKg,
            delivery.PointsEarned,
            delivery.CreatedAt);
    }

    public async Task<DeliveryDto?> UpdateDelivery(int id, DeliveryUpdateDto dto)
    {
        var delivery = await _context.Deliveries.FindAsync(id);
        if (delivery == null)
            return null;

        var user = await _context.Users.FindAsync(delivery.UserId);
        if (user == null)
            throw new InvalidOperationException("Usuario no encontrado");

        var previousPoints = delivery.PointsEarned;
        var wasteType = dto.WasteType;
        var newPoints = _pointsService.CalculatePoints(wasteType.ToString(), dto.QuantityKg);

        delivery.WasteType = wasteType;
        delivery.QuantityKg = dto.QuantityKg;
        delivery.PointsEarned = newPoints;

        user.Points += (newPoints - previousPoints);

        await _context.SaveChangesAsync();

        return new DeliveryDto(
            delivery.Id,
            delivery.UserId,
            new UserDto(user.Id, user.Dni, user.FullName, user.Points, user.Role),
            delivery.WasteType,
            delivery.QuantityKg,
            delivery.PointsEarned,
            delivery.CreatedAt);
    }

    public async Task<bool> DeleteDelivery(int id)
    {
        var delivery = await _context.Deliveries.FindAsync(id);
        if (delivery == null)
            return false;

        var user = await _context.Users.FindAsync(delivery.UserId);
        if (user != null)
            user.Points -= delivery.PointsEarned;

        _context.Deliveries.Remove(delivery);
        await _context.SaveChangesAsync();

        return true;
    }
}
