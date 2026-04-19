using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using shared;

namespace api.Services;

public class RedemptionService
{
    private readonly AppDbContext _context;

    public RedemptionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<RedemptionDto>> ListRedemptions()
    {
        return await _context.Redemptions
            .Select(r => new RedemptionDto(r.Id, r.UserId, r.RewardId, r.PointsSpent, r.Code, r.CreatedAt))
            .ToListAsync();
    }

    public async Task<RedemptionDto?> GetRedemptionById(int id)
    {
        var redemption = await _context.Redemptions.FindAsync(id);
        return redemption == null ? null : ToDto(redemption);
    }

    public async Task<RedemptionDto> CreateRedemption(RedemptionCreateDto dto)
    {
        var user = await _context.Users.FindAsync(dto.UserId);
        if (user == null)
            throw new InvalidOperationException("Usuario no encontrado");

        var reward = await _context.Rewards.FindAsync(dto.RewardId);
        if (reward == null)
            throw new InvalidOperationException("Premio no encontrado");

        if (reward.Stock <= 0)
            throw new InvalidOperationException("No hay stock disponible para el premio");

        if (user.Points < reward.RequiredPoints)
            throw new InvalidOperationException("El usuario no tiene puntos suficientes");

        if (dto.PointsSpent != reward.RequiredPoints)
            throw new InvalidOperationException("Los puntos enviados no coinciden con el costo del premio");

        user.Points -= reward.RequiredPoints;
        reward.Stock -= 1;

        var redemption = new Redemption
        {
            UserId = dto.UserId,
            RewardId = dto.RewardId,
            PointsSpent = reward.RequiredPoints,
            Code = await GenerateUniqueCodeAsync(),
            CreatedAt = DateTime.UtcNow
        };

        _context.Redemptions.Add(redemption);
        await _context.SaveChangesAsync();

        return ToDto(redemption);
    }

    public async Task<bool> DeleteRedemption(int id)
    {
        var redemption = await _context.Redemptions.FindAsync(id);
        if (redemption == null)
            return false;

        var user = await _context.Users.FindAsync(redemption.UserId);
        var reward = await _context.Rewards.FindAsync(redemption.RewardId);

        if (user == null || reward == null)
            throw new InvalidOperationException("No se pudo revertir el canje porque faltan datos relacionados");

        user.Points += redemption.PointsSpent;
        reward.Stock += 1;

        _context.Redemptions.Remove(redemption);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<RedemptionDto?> GetRedemptionByCode(string code)
    {
        var normalizedCode = (code ?? string.Empty).Trim();
        if (string.IsNullOrWhiteSpace(normalizedCode))
            return null;

        var redemption = await _context.Redemptions.FirstOrDefaultAsync(r => r.Code == normalizedCode);
        return redemption == null ? null : ToDto(redemption);
    }

    private async Task<string> GenerateUniqueCodeAsync()
    {
        string code;
        do
        {
            code = Random.Shared.Next(1_000_000, 10_000_000).ToString();
        }
        while (await _context.Redemptions.AnyAsync(r => r.Code == code));

        return code;
    }

    private static RedemptionDto ToDto(Redemption redemption) =>
        new(redemption.Id, redemption.UserId, redemption.RewardId, redemption.PointsSpent, redemption.Code, redemption.CreatedAt);
}
