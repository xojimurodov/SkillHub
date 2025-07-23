using SkillHub.DTOs;

namespace SkillHub.Interfaces;

public interface IGradeService
{
    Task<GradeDto> CreateAsync(GradeCreateDto dto);
    Task<List<GradeDto>> GetAllAsync();
    Task<List<GradeDto>> GetByStudentIdAsync(int studentId);
    Task<List<StudentRatingDto>> GetTopRatedStudentsAsync(int count);

}
