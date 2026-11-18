using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CategoryRepository(ApplicationDbContext appDbContext) : ICategoryRepository
{
    private readonly ApplicationDbContext _context = appDbContext;

    public async Task<bool> AddCategoryAsync(Category category)
    {
        _context.Categories.Add(category);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (category != null)
        {
            _context.Categories.Remove(category);
        }
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> UpdateCategoryAsync(Category category)
    {
        var c = await _context.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
        if (c != null)
        {
            c.Name = category.Name;
        }
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<Category> GetCategoryAsync(int id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        return category ?? new();
    }

    public async Task<List<Category>> GetCategorysAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<int> GetAmountOfCategorysAsync()
    {
        return await _context.Categories.CountAsync();
    }
}