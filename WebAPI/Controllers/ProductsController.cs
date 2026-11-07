using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    private IProductService service = productService;

    [HttpGet]
    public async Task<ApiResponse<List<Products>>> GetProducts()
    {
        return await service.GetProductsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Products>> GetProduct(int id)
    {
        return await service.GetProductsAsync(id);
    }

    [HttpGet("by-category/{categoryId:int}")]
    public async Task<ApiResponse<List<Products>>> GetProductsByCategory(int categoryId)
    {
        return await service.GetProductsByCategoryAsync(categoryId);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddProduct(Products product)
    {
        return await service.AddProductsAsync(product);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateProduct(Products product)
    {
        return await service.UpdateProductsAsync(product);
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