using System.ComponentModel.DataAnnotations;

namespace AspNet1.Dtos.Order;

public record UpdateOrderDto(
    [Required] Guid PizzaId, 
    [Required][Range(1, 100)] int Quantity,
    [Required][EmailAddress] string ClientEmail,
    [MaxLength(50)] string Title,
    [MaxLength(200)] string Description
);