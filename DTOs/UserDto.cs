namespace SkillHub.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public Role Role { get; set; }

    public string? Course { get; set; }
    public string? Subject { get; set; }
    public string? Bio { get; set; }
}
