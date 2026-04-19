using shared.Enums;

namespace shared;

public record DeliveryDto(int Id, int UserId, WasteTypeEnums WasteType, decimal QuantityKg, int PointsEarned, DateTime CreatedAt);
public record DeliveryCreateDto(int UserId, WasteTypeEnums WasteType, decimal QuantityKg);
public record DeliveryUpdateDto(WasteTypeEnums WasteType, decimal QuantityKg);