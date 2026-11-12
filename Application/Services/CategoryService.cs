using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    private ICategoryRepository repository = categoryRepository;

    public async Task<ApiResponse<bool>> AddCategoryAsync(CreateCategoryDto dto)
    {
        var category = new Category()
        {
            Name = dto.Name
        };
        var res = await repository.AddCategoryAsync(category);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> UpdateCategoryAsync(UpdateCategoryDto dto)
    {
        var category = new Category()
        {
            Id = dto.Id,
            Name = dto.Name
        };
        var res = await repository.UpdateCategoryAsync(category);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }

    public async Task<ApiResponse<bool>> DeleteCategoryAsync(int id)
    {
        var res = await repository.DeleteCategoryAsync(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", res);
    }

    public async Task<ApiResponse<GetCategoryDto>> GetCategoryAsync(int id)
    {
        var res = await repository.GetCategoryAsync(id);
        return res != null
        ? new ApiResponse<GetCategoryDto>(HttpStatusCode.OK, "Category with given id.", new GetCategoryDto()
        {
            Id = res.Id,
            Name = res.Name
        })
        : new ApiResponse<GetCategoryDto>(HttpStatusCode.NotFound, "No category with given id.");
    }

    public async Task<ApiResponse<List<GetCategoryDto>>> GetCategorysAsync()
    {
        var categories = await repository.GetCategorysAsync();
        var res = categories.Select(v => new GetCategoryDto()
        {
            Id = v.Id,
            Name = v.Name
        }).ToList();
        return new ApiResponse<List<GetCategoryDto>>(HttpStatusCode.OK, "List of categories.", res);
    }

    public async Task<ApiResponse<int>> GetAmountOfCategorysAsync()
    {
        var res = await repository.GetAmountOfCategorysAsync();
        return new ApiResponse<int>(HttpStatusCode.OK, "Amount of categories.", res);
    }
}