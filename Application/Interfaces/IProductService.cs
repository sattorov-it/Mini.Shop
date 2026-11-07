using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IProductService
{
    Task<ApiResponse<bool>> AddProductsAsync(Products product);
    Task<ApiResponse<bool>> UpdateProductsAsync(Products product);
    Task<ApiResponse<bool>> DeleteProductsAsync(int id);
    Task<ApiResponse<Products>> GetProductsAsync(int id);
    Task<ApiResponse<List<Products>>> GetProductsAsync();
    Task<ApiResponse<List<Products>>> GetProductsByCategoryAsync(int categoryId);
    Task<ApiResponse<int>> GetAmountOfProductsAsync();
    Task<ApiResponse<int>> GetAmountOfProductsByCategoryAsync(int categoryId);
    Task<ApiResponse<decimal>> GetMinPriceOfProductByCategoryAsync(int categoryId);
    Task<ApiResponse<decimal>> GetMaxPriceOfProductByCategoryAsync(int categoryId);
    Task<ApiResponse<decimal>> GetAveragePriceOfProductByCategoryAsync(int categoryId);
    Task<ApiResponse<decimal>> GetTotalPriceOfProductsAsync();
}