namespace shared;

public record RewardDto(int Id, string Name, int RequiredPoints, int Stock);
public record RewardCreateDto(string Name, int RequiredPoints, int Stock);
public record RewardUpdateDto(string Name, int RequiredPoints, int Stock);
