using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using shared;

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
            .Select(d => new DeliveryDto(d.Id, d.UserId, d.WasteType.ToString(), d.QuantityKg, d.PointsEarned, d.CreatedAt))
            .ToListAsync();
    }

    public async Task<DeliveryDto?> GetDeliveryById(int id)
    {
        var delivery = await _context.Deliveries.FindAsync(id);
        return delivery == null ? null : ToDto(delivery);
    }

    public async Task<DeliveryDto> RegisterDelivery(DeliveryCreateDto dto)
    {
        var user = await _context.Users.FindAsync(dto.UserId);
        if (user == null)
            throw new InvalidOperationException("Usuario no encontrado");

        var wasteType = ParseWasteType(dto.WasteType);
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

        return ToDto(delivery);
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
        var wasteType = ParseWasteType(dto.WasteType);
        var newPoints = _pointsService.CalculatePoints(wasteType.ToString(), dto.QuantityKg);

        delivery.WasteType = wasteType;
        delivery.QuantityKg = dto.QuantityKg;
        delivery.PointsEarned = newPoints;

        user.Points += (newPoints - previousPoints);

        await _context.SaveChangesAsync();

        return ToDto(delivery);
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

    private static DeliveryDto ToDto(Delivery d) =>
        new(
            d.Id,
            d.UserId,
            d.WasteType.ToString(),
            d.QuantityKg,
            d.PointsEarned,
            d.CreatedAt
        );

    private static WasteTypeEnums ParseWasteType(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidOperationException("Tipo de residuo inválido");

        var normalized = value.Trim();

        if (normalized.Equals("plastico", StringComparison.OrdinalIgnoreCase))
            return WasteTypeEnums.Plastic;

        if (normalized.Equals("carton", StringComparison.OrdinalIgnoreCase))
            return WasteTypeEnums.Paper;

        if (normalized.Equals("vidrio", StringComparison.OrdinalIgnoreCase))
            return WasteTypeEnums.Glass;

        if (Enum.TryParse<WasteTypeEnums>(normalized, ignoreCase: true, out var wasteType))
            return wasteType;

        throw new InvalidOperationException($"Tipo de residuo inválido: '{value}'");
    }
}
