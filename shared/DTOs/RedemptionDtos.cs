namespace shared;

public record RedemptionDto(int Id, int UserId, int RewardId, int PointsSpent, string Code, DateTime CreatedAt);
public record RedemptionCreateDto(int UserId, int RewardId, int PointsSpent);
