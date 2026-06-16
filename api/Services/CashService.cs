using api.Data;
using Microsoft.EntityFrameworkCore;
using shared;

namespace api.Services;

// Caja con saldo derivado: no existe tabla de caja. El resumen y los movimientos
// se calculan al vuelo a partir de las ventas (ingresos) y las entregas (egresos).
public class CashService
{
    private readonly AppDbContext _context;

    public CashService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CashSummaryDto> GetSummary()
    {
        var totalIncome = await _context.Sales.SumAsync(s => (decimal?)s.Amount) ?? 0m;
        var totalExpense = await _context.Deliveries.SumAsync(d => (decimal?)d.AmountPaid) ?? 0m;

        return new CashSummaryDto(totalIncome, totalExpense, totalIncome - totalExpense);
    }

    public async Task<List<CashMovementDto>> GetMovements()
    {
        var incomes = await _context.Sales
            .Select(s => new CashMovementDto(
                s.CreatedAt,
                "Ingreso",
                s.Amount,
                "Venta: " + s.Reward.Name))
            .ToListAsync();

        var expenses = await _context.Deliveries
            .Select(d => new CashMovementDto(
                d.CreatedAt,
                "Egreso",
                d.AmountPaid,
                "Entrega: " + d.WasteType + " (" + d.User.FullName + ")"))
            .ToListAsync();

        return incomes
            .Concat(expenses)
            .OrderByDescending(m => m.Date)
            .ToList();
    }
}
