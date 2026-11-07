
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class CategoryRepository(AppDbContext appDbContext) : ICategoryRepository
{
    private AppDbContext _context = appDbContext;
    public async Task<bool> AddCategoryAsync(Category category)
    {
        var connection = _context.Connection();
        // connection.Open();
        var query = "insert into categories (name) values (@name)";
        var res = await connection.ExecuteAsync(query, category);
        return res > 0;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var connection = _context.Connection();
        // connection.Open();
        var query = "delete from categories where id = @id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<bool> UpdateCategoryAsync(Category category)
    {
        var connection = _context.Connection();
        // connection.Open();
        var query = "update categories set name = @name where id = @id";
        var res = await connection.ExecuteAsync(query, category);
        return res > 0;
    }

    public async Task<Category> GetCategoryAsync(int id)
    {
        var connection = _context.Connection();
        // connection.Open();
        var query = "select * from categories where id = @id";
        var category = await connection.QuerySingleOrDefaultAsync<Category>(query, new { id });
        return category!;
    }

    public async Task<List<Category>> GetCategorysAsync()
    {
        var connection = _context.Connection();
        // connection.Open();
        var query = "select * from categories";
        var categories = await connection.QueryAsync<Category>(query);
        return categories.ToList();
    }

    public async Task<int> GetAmountOfCategorysAsync()
    {
        var connection = _context.Connection();
        // connection.Open();
        var query = "select count(*) from categories";
        var amount = await connection.ExecuteScalarAsync<int>(query);
        return amount;
    }
}
