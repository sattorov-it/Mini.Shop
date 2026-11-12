using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(
    ICategoryService categoryService,
    ILogger<CategoriesController> logger) : ControllerBase
{
    private ICategoryService service = categoryService;
    private ILogger<CategoriesController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<GetCategoryDto>>> GetCategorys()
    {
        _logger.LogInformation("Request received.");
        var res = await service.GetCategorysAsync();
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GetCategoryDto>> GetCategory(int id)
    {
        _logger.LogInformation("Request received.");
        var res = await service.GetCategoryAsync(id);
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCategory(CreateCategoryDto dto)
    {
        _logger.LogInformation("Request received.");
        var res = await service.AddCategoryAsync(dto);
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateCategory(UpdateCategoryDto dto)
    {
        _logger.LogInformation("Request received.");
        var res = await service.UpdateCategoryAsync(dto);
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCategory(int id)
    {
        _logger.LogInformation("Request received.");
        var res = await service.DeleteCategoryAsync(id);
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpGet("amount")]
    public async Task<ApiResponse<int>> GetAmountOfCategorys()
    {
        _logger.LogInformation("Request received.");
        var res = await service.GetAmountOfCategorysAsync();
        _logger.LogInformation("Response sent.");
        return res;
    }
}