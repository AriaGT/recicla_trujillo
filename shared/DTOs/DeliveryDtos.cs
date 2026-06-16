using shared.Enums;

namespace shared;

public record DeliveryDto(int Id, int UserId, UserDto User, WasteTypeEnums WasteType, decimal QuantityKg, decimal AmountPaid, DateTime CreatedAt);
public record DeliveryCreateDto(int UserId, WasteTypeEnums WasteType, decimal QuantityKg);
public record DeliveryUpdateDto(WasteTypeEnums WasteType, decimal QuantityKg);
