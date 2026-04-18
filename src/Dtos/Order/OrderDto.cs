namespace AspNet1.Dtos;

public record OrderDto(
    Guid Id,
    string Title, 
    string Description, 
    string PizzaName, // виводимо назву піци замість ID для зручності
    int Quantity,
    decimal TotalPrice,
    DateTime OrderDate
);