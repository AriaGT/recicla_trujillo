namespace api.Services;

public class PointsService
{
    public int CalculatePoints(string wasteType, decimal quantityKg)
    {
        var normalizedWasteType = wasteType?.Trim().ToLowerInvariant() ?? string.Empty;

        var pointsPerKg = normalizedWasteType switch
        {
            "plastico" or "plastic" => 10,
            "carton" or "paper" => 8,
            "vidrio" or "glass" => 6,
            "metal" => 7,
            _ => 5
        };

        return (int)(pointsPerKg * quantityKg);
    }
}
