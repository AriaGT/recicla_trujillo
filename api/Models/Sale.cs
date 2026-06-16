namespace api.Models;

public class Sale
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int RewardId { get; set; }
    public Reward Reward { get; set; } = null!;

    public decimal Amount { get; set; }
    public string Code { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
