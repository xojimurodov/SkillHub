namespace SkillHub.DTOs;

public class GradeDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public string StudentName { get; set; } = "";
    public int TeacherId { get; set; }
    public string TeacherName { get; set; } = "";
    public int Value { get; set; }
    public DateTime CreatedAt { get; set; }
}
