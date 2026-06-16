using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using shared;

namespace api.Services;

public class DeliveryService
{
    private readonly AppDbContext _context;
    private readonly PricingService _pricingService;

    public DeliveryService(AppDbContext context, PricingService pricingService)
    {
        _context = context;
        _pricingService = pricingService;
    }

    public async Task<List<DeliveryDto>> ListDeliveries()
    {
        return await _context.Deliveries
            .Include(d => d.User)
            .AsNoTracking()
            .Select(d => new DeliveryDto(
                d.Id,
                d.UserId,
                new UserDto(d.User.Id, d.User.Dni, d.User.FullName, d.User.Role),
                d.WasteType,
                d.QuantityKg,
                d.AmountPaid,
                d.CreatedAt))
            .ToListAsync();
    }

    public async Task<DeliveryDto?> GetDeliveryById(int id)
    {
        var delivery = await _context.Deliveries
            .Include(d => d.User)
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == id);

        return delivery == null ? null : ToDto(delivery, delivery.User);
    }

    public async Task<DeliveryDto> RegisterDelivery(DeliveryCreateDto dto)
    {
        var user = await _context.Users.FindAsync(dto.UserId);
        if (user == null)
            throw new InvalidOperationException("Usuario no encontrado");

        var wasteType = dto.WasteType;
        var amountPaid = _pricingService.CalculateAmount(wasteType.ToString(), dto.QuantityKg);

        var delivery = new Delivery
        {
            UserId = dto.UserId,
            WasteType = wasteType,
            QuantityKg = dto.QuantityKg,
            AmountPaid = amountPaid
        };

        _context.Deliveries.Add(delivery);
        await _context.SaveChangesAsync();

        return ToDto(delivery, user);
    }

    public async Task<DeliveryDto?> UpdateDelivery(int id, DeliveryUpdateDto dto)
    {
        var delivery = await _context.Deliveries.FindAsync(id);
        if (delivery == null)
            return null;

        var user = await _context.Users.FindAsync(delivery.UserId);
        if (user == null)
            throw new InvalidOperationException("Usuario no encontrado");

        delivery.WasteType = dto.WasteType;
        delivery.QuantityKg = dto.QuantityKg;
        delivery.AmountPaid = _pricingService.CalculateAmount(dto.WasteType.ToString(), dto.QuantityKg);

        await _context.SaveChangesAsync();

        return ToDto(delivery, user);
    }

    public async Task<bool> DeleteDelivery(int id)
    {
        var delivery = await _context.Deliveries.FindAsync(id);
        if (delivery == null)
            return false;

        _context.Deliveries.Remove(delivery);
        await _context.SaveChangesAsync();

        return true;
    }

    private static DeliveryDto ToDto(Delivery delivery, User user) =>
        new(delivery.Id,
            delivery.UserId,
            new UserDto(user.Id, user.Dni, user.FullName, user.Role),
            delivery.WasteType,
            delivery.QuantityKg,
            delivery.AmountPaid,
            delivery.CreatedAt);
}
