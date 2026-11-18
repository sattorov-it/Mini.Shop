using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepository(ApplicationDbContext appDbContext) : IProductRepository
{
    private readonly ApplicationDbContext _context = appDbContext;

    public async Task<bool> AddProductsAsync(Products product)
    {
        _context.Products.Add(product);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> UpdateProductsAsync(Products product)
    {
        var p = await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
        if (p != null)
        {
            p.Name = product.Name;
            p.Price = product.Price;
            p.CategoryId = product.CategoryId;
        }
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteProductsAsync(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (product != null)
        {
            _context.Products.Remove(product);
        }
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<Products> GetProductsAsync(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        return product ?? new();
    }

    public async Task<List<Products>> GetProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<List<Products>> GetProductsByCategoryAsync(int categoryId)
    {
        return await _context.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
    }

    public async Task<int> GetAmountOfProductsAsync()
    {
        return await _context.Products.CountAsync();
    }

    public async Task<int> GetAmountOfProductsByCategoryAsync(int categoryId)
    {
        return await _context.Products.CountAsync(x => x.CategoryId == categoryId);
    }

    public async Task<decimal> GetMinPriceOfProductByCategoryAsync(int categoryId)
    {
        return await _context.Products.Where(x => x.CategoryId == categoryId).MinAsync(x => (decimal?)x.Price) ?? 0;
    }

    public async Task<decimal> GetMaxPriceOfProductByCategoryAsync(int categoryId)
    {
        return await _context.Products.Where(x => x.CategoryId == categoryId).MaxAsync(x => (decimal?)x.Price) ?? 0;
    }

    public async Task<decimal> GetAveragePriceOfProductByCategoryAsync(int categoryId)
    {
        return await _context.Products.Where(x => x.CategoryId == categoryId).AverageAsync(x => (decimal?)x.Price) ?? 0;
    }

    public async Task<decimal> GetTotalPriceOfProductsAsync()
    {
        return await _context.Products.SumAsync(x => x.Price);
    }
}