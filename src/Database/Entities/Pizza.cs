using System.ComponentModel.DataAnnotations;

namespace AspNet1.Database.Entities;

public class Pizza
{
    public Guid Id { get; set; } =  Guid.NewGuid();
    [MaxLength(50)]
    public string? Name { get; set; } = string.Empty;
    [MaxLength(250)]
    public string? Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}