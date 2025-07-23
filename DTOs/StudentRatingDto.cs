namespace SkillHub.DTOs;

public class StudentRatingDto
{
    public int StudentId { get; set; }
    public required string Name { get; set; }
    public double AverageGrade { get; set; }
    public int GradesCount { get; set; }
}
