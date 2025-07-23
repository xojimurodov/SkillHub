using Microsoft.AspNetCore.Mvc;
using SkillHub.DTOs;
using SkillHub.Interfaces;

namespace SkillHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GradesController : ControllerBase
{
    private readonly IGradeService _gradeService;

    public GradesController(IGradeService gradeService)
    {
        _gradeService = gradeService;
    }

    [HttpPost]
    public async Task<ActionResult<GradeDto>> Create(GradeCreateDto dto)
    {
        try
        {
            var grade = await _gradeService.CreateAsync(dto);
            return Ok(grade);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<GradeDto>>> GetAll()
    {
        var grades = await _gradeService.GetAllAsync();
        return Ok(grades);
    }


    [HttpGet("student/{studentId}")]
    public async Task<ActionResult<List<GradeDto>>> GetByStudent(int studentId)
    {
        var grades = await _gradeService.GetByStudentIdAsync(studentId);
        return Ok(grades);
    }

    [HttpGet("top/{count}")]
    public async Task<ActionResult<List<StudentRatingDto>>> GetTopRated(int count)
    {
        var topStudents = await _gradeService.GetTopRatedStudentsAsync(count);
        return Ok(topStudents);
    }

}
