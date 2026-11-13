using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    private ICategoryService service = categoryService;

    [HttpGet]
    public async Task<ApiResponse<List<GetCategoryDto>>> GetCategorys()
    {
        return await service.GetCategorysAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GetCategoryDto>> GetCategory(int id)
    {
        return await service.GetCategoryAsync(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCategory(CreateCategoryDto dto)
    {
        return await service.AddCategoryAsync(dto);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateCategory(UpdateCategoryDto dto)
    {
        return await service.UpdateCategoryAsync(dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCategory(int id)
    {
        return await service.DeleteCategoryAsync(id);
    }

    [HttpGet("amount")]
    public async Task<ApiResponse<int>> GetAmountOfCategorys()
    {
        return await service.GetAmountOfCategorysAsync();
    }
}