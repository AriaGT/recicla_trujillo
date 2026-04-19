namespace shared;

public record DeliveryDto(int Id, int UserId, string WasteType, decimal QuantityKg, int PointsEarned, DateTime CreatedAt);
public record DeliveryCreateDto(int UserId, string WasteType, decimal QuantityKg);
public record DeliveryUpdateDto(string WasteType, decimal QuantityKg);
