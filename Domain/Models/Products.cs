using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

[Table("Products")]
public class Products
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = null!;

    [Range(0, 1000000)]
    public decimal Price { get; set; }

    [ForeignKey("Category")]
    public int CategoryId { get; set; }

    // Navigation property
    public Category Category { get; set; } = null!;
}