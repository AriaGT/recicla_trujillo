namespace shared;

// Resumen de caja calculado al vuelo: ingresos (ventas) − egresos (entregas pagadas).
public record CashSummaryDto(decimal TotalIncome, decimal TotalExpense, decimal Balance);

// Movimiento individual de caja. Type es "Ingreso" o "Egreso".
public record CashMovementDto(DateTime Date, string Type, decimal Amount, string Concept);
