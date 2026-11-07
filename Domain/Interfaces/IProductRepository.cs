using Domain.Models;

namespace Domain.Interfaces;

public interface IProductRepository
{
    Task<bool> AddProductsAsync(Products product);
    Task<bool> UpdateProductsAsync(Products product);
    Task<bool> DeleteProductsAsync(int id);
    Task<Products> GetProductsAsync(int id);
    Task<List<Products>> GetProductsAsync();
    Task<List<Products>> GetProductsByCategoryAsync(int categoryId);
    Task<int> GetAmountOfProductsAsync();
    Task<int> GetAmountOfProductsByCategoryAsync(int categoryId);
    Task<decimal> GetMinPriceOfProductByCategoryAsync(int categoryId);
    Task<decimal> GetMaxPriceOfProductByCategoryAsync(int categoryId);
    Task<decimal> GetAveragePriceOfProductByCategoryAsync(int categoryId);
    Task<decimal> GetTotalPriceOfProductsAsync();
}