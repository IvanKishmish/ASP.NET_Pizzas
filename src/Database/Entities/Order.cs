using System.ComponentModel.DataAnnotations;

namespace AspNet1.Database.Entities;

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PizzaId { get; set; }
    [MaxLength(50)]
    public string Title { get; set; } = string.Empty;
    [MaxLength(200)]
    public string Description { get; set; } = string.Empty;
    public Pizza? Pizza { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; } =  DateTime.UtcNow;
    public decimal TotalPrice { get; set; }
    [MaxLength(60)]
    public string ClientEmail { get; set; } = string.Empty;
}