namespace SkillHub.DTOs;

public class UserCreateDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required Role Role { get; set; }

    public string? Course { get; set; }
    public string? Subject { get; set; }
    public string? Bio { get; set; }
}
