namespace api.Models;

public class Reward
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int RequiredPoints { get; set; }
    public int Stock { get; set; }
}

