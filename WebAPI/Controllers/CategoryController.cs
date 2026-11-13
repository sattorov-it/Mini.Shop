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
        var res = await service.GetCategoryAsync(id);
        return res;
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCategory(CreateCategoryDto dto)
    {
        var res = await service.AddCategoryAsync(dto);
        return res;
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateCategory(UpdateCategoryDto dto)
    {
        var res = await service.UpdateCategoryAsync(dto);
        return res;
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCategory(int id)
    {
        var res = await service.DeleteCategoryAsync(id);
        return res;
    }

    [HttpGet("amount")]
    public async Task<ApiResponse<int>> GetAmountOfCategorys()
    {
        var res = await service.GetAmountOfCategorysAsync();
        return res;
    }
}