using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using shared;

namespace api.Services;

public class SaleService
{
    private readonly AppDbContext _context;

    public SaleService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<SaleDto>> ListSales(int? userId = null)
    {
        var query = _context.Sales.AsQueryable();

        if (userId.HasValue)
            query = query.Where(s => s.UserId == userId.Value);

        return await query
            .Select(s => new SaleDto(s.Id, s.UserId, s.RewardId, s.Amount, s.Code, s.CreatedAt))
            .ToListAsync();
    }

    public async Task<SaleDto?> GetSaleById(int id)
    {
        var sale = await _context.Sales.FindAsync(id);
        return sale == null ? null : ToDto(sale);
    }

    public async Task<SaleDto> CreateSale(SaleCreateDto dto)
    {
        var user = await _context.Users.FindAsync(dto.UserId);
        if (user == null)
            throw new InvalidOperationException("Usuario no encontrado");

        var reward = await _context.Rewards.FindAsync(dto.RewardId);
        if (reward == null)
            throw new InvalidOperationException("Premio no encontrado");

        if (reward.Stock <= 0)
            throw new InvalidOperationException("No hay stock disponible para el premio");

        reward.Stock -= 1;

        var sale = new Sale
        {
            UserId = dto.UserId,
            RewardId = dto.RewardId,
            Amount = reward.Price,
            Code = await GenerateUniqueCodeAsync(),
            CreatedAt = DateTime.UtcNow
        };

        _context.Sales.Add(sale);
        await _context.SaveChangesAsync();

        return ToDto(sale);
    }

    public async Task<bool> DeleteSale(int id)
    {
        var sale = await _context.Sales.FindAsync(id);
        if (sale == null)
            return false;

        var reward = await _context.Rewards.FindAsync(sale.RewardId);
        if (reward != null)
            reward.Stock += 1;

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<SaleDto?> GetSaleByCode(string code)
    {
        var normalizedCode = (code ?? string.Empty).Trim();
        if (string.IsNullOrWhiteSpace(normalizedCode))
            return null;

        var sale = await _context.Sales.FirstOrDefaultAsync(s => s.Code == normalizedCode);
        return sale == null ? null : ToDto(sale);
    }

    private async Task<string> GenerateUniqueCodeAsync()
    {
        string code;
        do
        {
            code = Random.Shared.Next(1_000_000, 10_000_000).ToString();
        }
        while (await _context.Sales.AnyAsync(s => s.Code == code));

        return code;
    }

    private static SaleDto ToDto(Sale sale) =>
        new(sale.Id, sale.UserId, sale.RewardId, sale.Amount, sale.Code, sale.CreatedAt);
}
