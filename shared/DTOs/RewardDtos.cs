namespace shared;

public record RewardDto(int Id, string Name, decimal Price, int Stock);
public record RewardCreateDto(string Name, decimal Price, int Stock);
public record RewardUpdateDto(string Name, decimal Price, int Stock);
