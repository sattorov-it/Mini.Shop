
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ProductRepository(AppDbContext appDbContext) : IProductRepository
{
    private AppDbContext _context = appDbContext;
    public async Task<bool> AddProductsAsync(Products product)
    {
        var connection = _context.Connection();
        // connection.Open();
        var query = "insert into products (name, price, categoryid) values (@name, @price, @categoryid)";
        var res = await connection.ExecuteAsync(query, product);
        return res > 0;
    }

    public async Task<bool> UpdateProductsAsync(Products product)
    {
        var connection = _context.Connection();
        // connection.Open();
        var query = "update products set name = @name, price = @price, categoryid = @categoryid where id = @id";
        var res = await connection.ExecuteAsync(query, product);
        return res > 0;
    }

    public async Task<bool> DeleteProductsAsync(int id)
    {
        var connection = _context.Connection();
        // connection.Open();
        var query = "delete from products where id = @id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<Products> GetProductsAsync(int id)
    {
        var connection = _context.Connection();
        // connection.Open();
        var query = "select * from products where id = @id";
        var product = await connection.QuerySingleAsync<Products>(query, new { id });
        return product;
    }

    public async Task<List<Products>> GetProductsAsync()
    {
        var connection = _context.Connection();
        // connection.Open();
        var query = "select * from products";
        var products = await connection.QueryAsync<Products>(query);
        return products.ToList();
    }

    public async Task<List<Products>> GetProductsByCategoryAsync(int categoryId)
    {
        var connection = _context.Connection();
        // connection.Open();
        var query = "select * from products where categoryid = @categoryId";
        var products = await connection.QueryAsync<Products>(query, new { categoryId });
        return products.ToList();
    }

    public async Task<int> GetAmountOfProductsAsync()
    {
        var connection = _context.Connection();
        // connection.Open();
        var query = "select count(*) from products";
        var amount = await connection.ExecuteScalarAsync<int>(query);
        return amount;
    }

    public async Task<int> GetAmountOfProductsByCategoryAsync(int categoryId)
    {
        var connection = _context.Connection();
        // connection.Open();
        var query = "select count(*) from products where categoryid = @categoryId";
        var amount = await connection.ExecuteScalarAsync<int>(query, new { categoryId });
        return amount;
    }

    public async Task<decimal> GetMinPriceOfProductByCategoryAsync(int categoryId)
    {
        var connection = _context.Connection();
        // connection.Open();
        var query = "select min(price) from products where categoryid = @categoryId";
        var price = await connection.ExecuteScalarAsync<decimal>(query, new { categoryId });
        return price;
    }

    public async Task<decimal> GetMaxPriceOfProductByCategoryAsync(int categoryId)
    {
        var connection = _context.Connection();
        // connection.Open();
        var query = "select max(price) from products where categoryid = @categoryId";
        var price = await connection.ExecuteScalarAsync<decimal>(query, new { categoryId });
        return price;
    }

    public async Task<decimal> GetAveragePriceOfProductByCategoryAsync(int categoryId)
    {
        var connection = _context.Connection();
        // connection.Open();
        var query = "select avg(price) from products where categoryid = @categoryId";
        var price = await connection.ExecuteScalarAsync<decimal>(query, new { categoryId });
        return price;
    }

    public async Task<decimal> GetTotalPriceOfProductsAsync()
    {
        var connection = _context.Connection();
        // connection.Open();
        var query = "select sum(price) from products";
        var price = await connection.ExecuteScalarAsync<decimal>(query);
        return price;
    }
}
