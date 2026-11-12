using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(
    IProductService productService,
    ILogger<ProductsController> logger) : ControllerBase
{
    private IProductService service = productService;
    private ILogger<ProductsController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<GetProductDto>>> GetProducts()
    {
        _logger.LogInformation("Request received.");
        var res = await service.GetProductsAsync();
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GetProductDto>> GetProduct(int id)
    {
        _logger.LogInformation("Request received.");
        var res = await service.GetProductsAsync(id);
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpGet("by-category/{categoryId:int}")]
    public async Task<ApiResponse<List<GetProductDto>>> GetProductsByCategory(int categoryId)
    {
        _logger.LogInformation("Request received.");
        var res = await service.GetProductsByCategoryAsync(categoryId);
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddProduct(CreateProductDto dto)
    {
        _logger.LogInformation("Request received.");
        var res = await service.AddProductsAsync(dto);
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateProduct(UpdateProductDto dto)
    {
        _logger.LogInformation("Request received.");
        var res = await service.UpdateProductsAsync(dto);
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteProduct(int id)
    {
        _logger.LogInformation("Request received.");
        var res = await service.DeleteProductsAsync(id);
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpGet("amount")]
    public async Task<ApiResponse<int>> GetAmountOfProducts()
    {
        _logger.LogInformation("Request received.");
        var res = await service.GetAmountOfProductsAsync();
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpGet("amount/by-category/{categoryId:int}")]
    public async Task<ApiResponse<int>> GetAmountOfProductsByCategory(int categoryId)
    {
        _logger.LogInformation("Request received.");
        var res = await service.GetAmountOfProductsByCategoryAsync(categoryId);
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpGet("min-price/by-category/{categoryId:int}")]
    public async Task<ApiResponse<decimal>> GetMinPriceByCategory(int categoryId)
    {
        _logger.LogInformation("Request received.");
        var res = await service.GetMinPriceOfProductByCategoryAsync(categoryId);
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpGet("max-price/by-category/{categoryId:int}")]
    public async Task<ApiResponse<decimal>> GetMaxPriceByCategory(int categoryId)
    {
        _logger.LogInformation("Request received.");
        var res = await service.GetMaxPriceOfProductByCategoryAsync(categoryId);
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpGet("average-price/by-category/{categoryId:int}")]
    public async Task<ApiResponse<decimal>> GetAveragePriceByCategory(int categoryId)
    {
        _logger.LogInformation("Request received.");
        var res = await service.GetAveragePriceOfProductByCategoryAsync(categoryId);
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpGet("total-price")]
    public async Task<ApiResponse<decimal>> GetTotalPrice()
    {
        _logger.LogInformation("Request received.");
        var res = await service.GetTotalPriceOfProductsAsync();
        _logger.LogInformation("Response sent.");
        return res;
    }
}