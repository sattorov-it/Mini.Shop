using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    private IProductRepository repository = productRepository;

    public async Task<ApiResponse<bool>> AddProductsAsync(CreateProductDto dto)
    {
        var product = new Products()
        {
            Name = dto.Name,
            Price = dto.Price,
            CategoryId = dto.CategoryId
        };
        var res = await repository.AddProductsAsync(product);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> UpdateProductsAsync(UpdateProductDto dto)
    {
        var product = new Products()
        {
            Id = dto.Id,
            Name = dto.Name,
            Price = dto.Price,
            CategoryId = dto.CategoryId
        };
        var res = await repository.UpdateProductsAsync(product);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }

    public async Task<ApiResponse<bool>> DeleteProductsAsync(int id)
    {
        var res = await repository.DeleteProductsAsync(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", res);
    }

    public async Task<ApiResponse<GetProductDto>> GetProductsAsync(int id)
    {
        var res = await repository.GetProductsAsync(id);
        return res != null
        ? new ApiResponse<GetProductDto>(HttpStatusCode.OK, "Product with given id.", new GetProductDto()
        {
            Id = res.Id,
            Name = res.Name,
            Price = res.Price,
            CategoryId = res.CategoryId
        })
        : new ApiResponse<GetProductDto>(HttpStatusCode.NotFound, "No product with given id.");
    }

    public async Task<ApiResponse<List<GetProductDto>>> GetProductsAsync()
    {
        var products = await repository.GetProductsAsync();
        var res = products.Select(v => new GetProductDto()
        {
            Id = v.Id,
            Name = v.Name,
            Price = v.Price,
            CategoryId = v.CategoryId
        }).ToList();
        return new ApiResponse<List<GetProductDto>>(HttpStatusCode.OK, "List of products.", res);
    }

    public async Task<ApiResponse<List<GetProductDto>>> GetProductsByCategoryAsync(int categoryId)
    {
        var products = await repository.GetProductsByCategoryAsync(categoryId);
        var res = products.Select(v => new GetProductDto()
        {
            Id = v.Id,
            Name = v.Name,
            Price = v.Price,
            CategoryId = v.CategoryId
        }).ToList();
        return new ApiResponse<List<GetProductDto>>(HttpStatusCode.OK, "List of products by category.", res);
    }

    public async Task<ApiResponse<int>> GetAmountOfProductsAsync()
    {
        var res = await repository.GetAmountOfProductsAsync();
        return new ApiResponse<int>(HttpStatusCode.OK, "Amount of products.", res);
    }

    public async Task<ApiResponse<int>> GetAmountOfProductsByCategoryAsync(int categoryId)
    {
        var res = await repository.GetAmountOfProductsByCategoryAsync(categoryId);
        return new ApiResponse<int>(HttpStatusCode.OK, "Amount of products by category.", res);
    }

    public async Task<ApiResponse<decimal>> GetMinPriceOfProductByCategoryAsync(int categoryId)
    {
        var res = await repository.GetMinPriceOfProductByCategoryAsync(categoryId);
        return new ApiResponse<decimal>(HttpStatusCode.OK, "Min price of product by category.", res);
    }

    public async Task<ApiResponse<decimal>> GetMaxPriceOfProductByCategoryAsync(int categoryId)
    {
        var res = await repository.GetMaxPriceOfProductByCategoryAsync(categoryId);
        return new ApiResponse<decimal>(HttpStatusCode.OK, "Max price of product by category.", res);
    }

    public async Task<ApiResponse<decimal>> GetAveragePriceOfProductByCategoryAsync(int categoryId)
    {
        var res = await repository.GetAveragePriceOfProductByCategoryAsync(categoryId);
        return new ApiResponse<decimal>(HttpStatusCode.OK, "Average price of product by category.", res);
    }

    public async Task<ApiResponse<decimal>> GetTotalPriceOfProductsAsync()
    {
        var res = await repository.GetTotalPriceOfProductsAsync();
        return new ApiResponse<decimal>(HttpStatusCode.OK, "Total price of products.", res);
    }
}