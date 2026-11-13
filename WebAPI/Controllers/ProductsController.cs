using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    private IProductService service = productService;

    [HttpGet]
    public async Task<ApiResponse<List<GetProductDto>>> GetProducts()
    {
        return await service.GetProductsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GetProductDto>> GetProduct(int id)
    {
        return await service.GetProductsAsync(id);
    }

    [HttpGet("by-category/{categoryId:int}")]
    public async Task<ApiResponse<List<GetProductDto>>> GetProductsByCategory(int categoryId)
    {
        return await service.GetProductsByCategoryAsync(categoryId);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddProduct(CreateProductDto dto)
    {
        return await service.AddProductsAsync(dto);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateProduct(UpdateProductDto dto)
    {
        return await service.UpdateProductsAsync(dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteProduct(int id)
    {
        return await service.DeleteProductsAsync(id);
    }

    [HttpGet("amount")]
    public async Task<ApiResponse<int>> GetAmountOfProducts()
    {
        return await service.GetAmountOfProductsAsync();
    }

    [HttpGet("amount/by-category/{categoryId:int}")]
    public async Task<ApiResponse<int>> GetAmountOfProductsByCategory(int categoryId)
    {
        return await service.GetAmountOfProductsByCategoryAsync(categoryId);
    }

    [HttpGet("min-price/by-category/{categoryId:int}")]
    public async Task<ApiResponse<decimal>> GetMinPriceByCategory(int categoryId)
    {
        return await service.GetMinPriceOfProductByCategoryAsync(categoryId);
    }

    [HttpGet("max-price/by-category/{categoryId:int}")]
    public async Task<ApiResponse<decimal>> GetMaxPriceByCategory(int categoryId)
    {
        return await service.GetMaxPriceOfProductByCategoryAsync(categoryId);
    }

    [HttpGet("average-price/by-category/{categoryId:int}")]
    public async Task<ApiResponse<decimal>> GetAveragePriceByCategory(int categoryId)
    {
        return await service.GetAveragePriceOfProductByCategoryAsync(categoryId);
    }

    [HttpGet("total-price")]
    public async Task<ApiResponse<decimal>> GetTotalPrice()
    {
        return await service.GetTotalPriceOfProductsAsync();
    }
}