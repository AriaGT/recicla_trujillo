namespace api.Services;

public class PricingService
{
    // Tarifa monetaria (S/ por kg) pagada al ciudadano según el tipo de residuo entregado.
    public decimal CalculateAmount(string wasteType, decimal quantityKg)
    {
        var normalizedWasteType = wasteType?.Trim().ToLowerInvariant() ?? string.Empty;

        var ratePerKg = normalizedWasteType switch
        {
            "plastico" or "plastic" => 1.00m,
            "carton" or "paper" => 0.80m,
            "vidrio" or "glass" => 0.60m,
            "metal" => 0.70m,
            _ => 0.50m
        };

        return ratePerKg * quantityKg;
    }
}
