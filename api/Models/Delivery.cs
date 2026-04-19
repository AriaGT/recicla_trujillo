using shared.Enums;

namespace api.Models;

public class Delivery
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public WasteTypeEnums WasteType { get; set; }
    public decimal QuantityKg { get; set; }
    public int PointsEarned { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
