namespace SkillHub.Models;

public class Grade
{
    public int Id { get; set; }

    public int StudentId { get; set; }
    public User Student { get; set; } = null!;

    public int TeacherId { get; set; }
    public User Teacher { get; set; } = null!;

    public int Value { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
