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
        var res = await service.GetProductsAsync();
        return res;
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GetProductDto>> GetProduct(int id)
    {
        var res = await service.GetProductsAsync(id);
        return res;
    }

    [HttpGet("by-category/{categoryId:int}")]
    public async Task<ApiResponse<List<GetProductDto>>> GetProductsByCategory(int categoryId)
    {
        var res = await service.GetProductsByCategoryAsync(categoryId);
        return res;
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddProduct(CreateProductDto dto)
    {
        var res = await service.AddProductsAsync(dto);
        return res;
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateProduct(UpdateProductDto dto)
    {
        var res = await service.UpdateProductsAsync(dto);
        return res;
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteProduct(int id)
    {
        var res = await service.DeleteProductsAsync(id);
        return res;
    }

    [HttpGet("amount")]
    public async Task<ApiResponse<int>> GetAmountOfProducts()
    {
        var res = await service.GetAmountOfProductsAsync();
        return res;
    }

    [HttpGet("amount/by-category/{categoryId:int}")]
    public async Task<ApiResponse<int>> GetAmountOfProductsByCategory(int categoryId)
    {
        var res = await service.GetAmountOfProductsByCategoryAsync(categoryId);
        return res;
    }

    [HttpGet("min-price/by-category/{categoryId:int}")]
    public async Task<ApiResponse<decimal>> GetMinPriceByCategory(int categoryId)
    {
        var res = await service.GetMinPriceOfProductByCategoryAsync(categoryId);
        return res;
    }

    [HttpGet("max-price/by-category/{categoryId:int}")]
    public async Task<ApiResponse<decimal>> GetMaxPriceByCategory(int categoryId)
    {
        var res = await service.GetMaxPriceOfProductByCategoryAsync(categoryId);
        return res;
    }

    [HttpGet("average-price/by-category/{categoryId:int}")]
    public async Task<ApiResponse<decimal>> GetAveragePriceByCategory(int categoryId)
    {
        var res = await service.GetAveragePriceOfProductByCategoryAsync(categoryId);
        return res;
    }

    [HttpGet("total-price")]
    public async Task<ApiResponse<decimal>> GetTotalPrice()
    {
        var res = await service.GetTotalPriceOfProductsAsync();
        return res;
    }
}