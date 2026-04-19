using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using shared;

namespace api.Services;

public class RewardsService
{
    private readonly AppDbContext _context;

    public RewardsService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<RewardDto>> ListRewards()
    {
        return await _context.Rewards
            .Select(r => new RewardDto(r.Id, r.Name, r.RequiredPoints, r.Stock))
            .ToListAsync();
    }

    public async Task<RewardDto?> GetRewardById(int id)
    {
        var reward = await _context.Rewards.FindAsync(id);
        return reward == null ? null : ToDto(reward);
    }

    public async Task<RewardDto> CreateReward(RewardCreateDto dto)
    {
        ValidateRewardDto(dto.Name, dto.RequiredPoints, dto.Stock);

        if (await _context.Rewards.AnyAsync(r => r.Name == dto.Name))
            throw new InvalidOperationException("Ya existe un premio con ese nombre");

        var reward = new Reward
        {
            Name = dto.Name,
            RequiredPoints = dto.RequiredPoints,
            Stock = dto.Stock
        };

        _context.Rewards.Add(reward);
        await _context.SaveChangesAsync();

        return ToDto(reward);
    }

    public async Task<RewardDto?> UpdateReward(int id, RewardUpdateDto dto)
    {
        var reward = await _context.Rewards.FindAsync(id);
        if (reward == null)
            return null;

        ValidateRewardDto(dto.Name, dto.RequiredPoints, dto.Stock);

        var nameInUse = await _context.Rewards.AnyAsync(r => r.Id != id && r.Name == dto.Name);
        if (nameInUse)
            throw new InvalidOperationException("Ya existe otro premio con ese nombre");

        reward.Name = dto.Name;
        reward.RequiredPoints = dto.RequiredPoints;
        reward.Stock = dto.Stock;

        await _context.SaveChangesAsync();

        return ToDto(reward);
    }

    public async Task<bool> DeleteReward(int id)
    {
        var reward = await _context.Rewards.FindAsync(id);
        if (reward == null)
            return false;

        _context.Rewards.Remove(reward);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<Reward?> GetEntityById(int id)
    {
        return await _context.Rewards.FindAsync(id);
    }

    private static void ValidateRewardDto(string name, int requiredPoints, int stock)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidOperationException("El nombre del premio es obligatorio");

        if (requiredPoints <= 0)
            throw new InvalidOperationException("Los puntos requeridos deben ser mayores que cero");

        if (stock < 0)
            throw new InvalidOperationException("El stock no puede ser negativo");
    }

    private static RewardDto ToDto(Reward reward) => new(reward.Id, reward.Name, reward.RequiredPoints, reward.Stock);
}
