
namespace SkillHub.Models;
public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required Role Role { get; set; }
    public required string Course { get; set; }
    public required string Subject { get; set; }
    public required string Bio { get; set; }
    public List<Grade> Grades { get; set; } = new();
}
