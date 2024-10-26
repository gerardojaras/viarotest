namespace Shared;

public class ColegioEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int CreatedBy { get; set; } = 1;
}