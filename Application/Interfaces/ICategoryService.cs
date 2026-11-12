using Application.DTOs;
using Application.Responses;
namespace Application.Interfaces;

public interface ICategoryService
{
    Task<ApiResponse<bool>> AddCategoryAsync(CreateCategoryDto dto);
    Task<ApiResponse<bool>> UpdateCategoryAsync(UpdateCategoryDto dto);
    Task<ApiResponse<bool>> DeleteCategoryAsync(int id);
    Task<ApiResponse<GetCategoryDto>> GetCategoryAsync(int id);
    Task<ApiResponse<List<GetCategoryDto>>> GetCategorysAsync();
    Task<ApiResponse<int>> GetAmountOfCategorysAsync();

}
