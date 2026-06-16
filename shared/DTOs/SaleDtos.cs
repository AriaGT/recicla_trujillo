namespace shared;

public record SaleDto(int Id, int UserId, int RewardId, decimal Amount, string Code, DateTime CreatedAt);
public record SaleCreateDto(int UserId, int RewardId);
