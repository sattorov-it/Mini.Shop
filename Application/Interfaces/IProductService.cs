using Application.DTOs;
using Application.Responses;
namespace Application.Interfaces;

public interface IProductService
{
    Task<ApiResponse<bool>> AddProductsAsync(CreateProductDto dto);
    Task<ApiResponse<bool>> UpdateProductsAsync(UpdateProductDto dto);
    Task<ApiResponse<bool>> DeleteProductsAsync(int id);
    Task<ApiResponse<GetProductDto>> GetProductsAsync(int id);
    Task<ApiResponse<List<GetProductDto>>> GetProductsAsync();
    Task<ApiResponse<List<GetProductDto>>> GetProductsByCategoryAsync(int categoryId);
    Task<ApiResponse<int>> GetAmountOfProductsAsync();
    Task<ApiResponse<int>> GetAmountOfProductsByCategoryAsync(int categoryId);
    Task<ApiResponse<decimal>> GetMinPriceOfProductByCategoryAsync(int categoryId);
    Task<ApiResponse<decimal>> GetMaxPriceOfProductByCategoryAsync(int categoryId);
    Task<ApiResponse<decimal>> GetAveragePriceOfProductByCategoryAsync(int categoryId);
    Task<ApiResponse<decimal>> GetTotalPriceOfProductsAsync();
}