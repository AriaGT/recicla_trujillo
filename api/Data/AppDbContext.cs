using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shared;

namespace api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users => Set<User>();
    public DbSet<Delivery> Deliveries => Set<Delivery>();
    public DbSet<Reward> Rewards => Set<Reward>();
    public DbSet<Redemption> Redemptions => Set<Redemption>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var userRoleConverter = new ValueConverter<UserRole, string>(
            role => role.ToString(),
            value => ParseUserRole(value));

        var wasteTypeConverter = new ValueConverter<WasteTypeEnums, string>(
            wasteType => wasteType.ToString(),
            value => ParseWasteType(value));

        modelBuilder.Entity<User>()
            .Property(x => x.Role)
            .HasConversion(userRoleConverter);

        modelBuilder.Entity<Delivery>()
            .Property(x => x.WasteType)
            .HasConversion(wasteTypeConverter);

        modelBuilder.Entity<Redemption>()
            .Property(x => x.Code)
            .HasMaxLength(7)
            .IsRequired();

        modelBuilder.Entity<Redemption>()
            .HasIndex(x => x.Code)
            .IsUnique();
    }

    private static UserRole ParseUserRole(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return UserRole.Citizen;

        var normalized = value.Trim();

        if (normalized.Equals("User", StringComparison.OrdinalIgnoreCase))
            return UserRole.Citizen;

        if (Enum.TryParse<UserRole>(normalized, ignoreCase: true, out var role))
            return role;

        throw new InvalidOperationException($"Rol inválido en base de datos: '{value}'");
    }

    private static WasteTypeEnums ParseWasteType(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return WasteTypeEnums.Plastic;

        var normalized = value.Trim();

        if (normalized.Equals("plastico", StringComparison.OrdinalIgnoreCase))
            return WasteTypeEnums.Plastic;

        if (normalized.Equals("carton", StringComparison.OrdinalIgnoreCase))
            return WasteTypeEnums.Paper;

        if (normalized.Equals("vidrio", StringComparison.OrdinalIgnoreCase))
            return WasteTypeEnums.Glass;

        if (Enum.TryParse<WasteTypeEnums>(normalized, ignoreCase: true, out var wasteType))
            return wasteType;

        throw new InvalidOperationException($"Tipo de residuo inválido en base de datos: '{value}'");
    }
}
