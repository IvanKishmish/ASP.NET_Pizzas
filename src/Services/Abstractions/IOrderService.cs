using AspNet1.Database.Entities;
using AspNet1.Dtos.Order;

namespace AspNet1.Services.Abstractions;

public interface IOrderService
{
    Task<List<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(Guid id);
    Task AddAsync(Order order);
    Task UpdateAsync(Guid id, UpdateOrderDto updatedOrder);
    Task UpdatePriceAsync(Guid id, decimal newPrice);
    Task DeleteAsync(Guid id);
}