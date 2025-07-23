using SkillHub.DTOs;
using SkillHub.Models;

namespace SkillHub.Interfaces;

public interface IUserService
{
    Task<UserDto?> GetByIdAsync(int id);
    Task<List<UserDto>> GetAllAsync();
    Task<UserDto> CreateAsync(UserCreateDto dto);
    Task<bool> UpdateAsync(int id, UserCreateDto dto);
    Task<bool> DeleteAsync(int id);
}
