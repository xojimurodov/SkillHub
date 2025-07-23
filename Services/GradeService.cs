using Microsoft.EntityFrameworkCore;
using SkillHub.Data;
using SkillHub.DTOs;
using SkillHub.Interfaces;
using SkillHub.Models;

namespace SkillHub.Services;

public class GradeService : IGradeService
{
    private readonly ApplicationDbContext _context;

    public GradeService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<GradeDto> CreateAsync(GradeCreateDto dto)
    {
        var student = await _context.Users.FindAsync(dto.StudentId);
        var teacher = await _context.Users.FindAsync(dto.TeacherId);

        if (student == null || student.Role != Role.Student)
            throw new Exception("Invalid student ID");

        if (teacher == null || teacher.Role != Role.Teacher)
            throw new Exception("Invalid teacher ID");

        var grade = new Grade
        {
            StudentId = dto.StudentId,
            TeacherId = dto.TeacherId,
            Value = dto.Value
        };

        _context.Grades.Add(grade);
        await _context.SaveChangesAsync();

        return await MapToDto(grade.Id);
    }

    public async Task<List<GradeDto>> GetAllAsync()
    {
        return await _context.Grades
            .Include(g => g.Student)
            .Include(g => g.Teacher)
            .Select(g => new GradeDto
            {
                Id = g.Id,
                StudentId = g.StudentId,
                StudentName = g.Student.Name,
                TeacherId = g.TeacherId,
                TeacherName = g.Teacher.Name,
                Value = g.Value,
                CreatedAt = g.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<List<GradeDto>> GetByStudentIdAsync(int studentId)
    {
        return await _context.Grades
            .Where(g => g.StudentId == studentId)
            .Include(g => g.Student)
            .Include(g => g.Teacher)
            .Select(g => new GradeDto
            {
                Id = g.Id,
                StudentId = g.StudentId,
                StudentName = g.Student.Name,
                TeacherId = g.TeacherId,
                TeacherName = g.Teacher.Name,
                Value = g.Value,
                CreatedAt = g.CreatedAt
            })
            .ToListAsync();
    }

    private async Task<GradeDto> MapToDto(int id)
    {
        var grade = await _context.Grades
            .Include(g => g.Student)
            .Include(g => g.Teacher)
            .FirstAsync(g => g.Id == id);

        return new GradeDto
        {
            Id = grade.Id,
            StudentId = grade.StudentId,
            StudentName = grade.Student.Name,
            TeacherId = grade.TeacherId,
            TeacherName = grade.Teacher.Name,
            Value = grade.Value,
            CreatedAt = grade.CreatedAt
        };
    }
    public async Task<List<StudentRatingDto>> GetTopRatedStudentsAsync(int count)
    {
        var ratings = await _context.Grades
            .Where(g => g.Student.Role == Role.Student)
            .GroupBy(g => new { g.StudentId, g.Student.Name })
            .Select(group => new StudentRatingDto
            {
                StudentId = group.Key.StudentId,
                Name = group.Key.Name,
                AverageGrade = group.Average(g => g.Value),
                GradesCount = group.Count()
            })
            .OrderByDescending(r => r.AverageGrade)
            .ThenByDescending(r => r.GradesCount)
            .Take(count)
            .ToListAsync();

        return ratings;
    }

}
