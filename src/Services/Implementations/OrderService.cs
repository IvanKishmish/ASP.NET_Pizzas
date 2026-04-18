using AspNet1.Database;
using AspNet1.Database.Entities;
using AspNet1.Dtos.Order;
using AspNet1.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace AspNet1.Services.Implementations;

public class OrderService(AppDbContext db, IPizzaService pizzaService) : IOrderService
{
    public async Task<List<Order>> GetAllAsync()
    {
        return await db.Orders
            .Include(o => o.Pizza)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await db.Orders
            .Include(o => o.Pizza)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task AddAsync(Order order)
    {
        var pizza =  await pizzaService.GetByIdAsync(order.PizzaId);

        if (pizza is not null)
        {
            order.TotalPrice = pizza.Price * order.Quantity;
            order.OrderDate = DateTime.UtcNow; 
            
            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(Guid id, UpdateOrderDto updatedOrder)
    {
        var existingOrder = await db.Orders.FindAsync(id);
        if (existingOrder is not null)
        {
            existingOrder.Title = updatedOrder.Title;
            existingOrder.Description = updatedOrder.Description; 
            existingOrder.PizzaId = updatedOrder.PizzaId; 
            existingOrder.Quantity = updatedOrder.Quantity;
            existingOrder.ClientEmail = updatedOrder.ClientEmail;

            await db.SaveChangesAsync();
        }
    }

    public async Task UpdatePriceAsync(Guid id, decimal newPrice)
    {
        await db.Orders
            .Where(o => o.Id == id)
            .ExecuteUpdateAsync(setters => setters.SetProperty(o => o.TotalPrice, newPrice));
    }

    public async Task DeleteAsync(Guid id)
    {
        await db.Orders.Where(o => o.Id == id).ExecuteDeleteAsync();
    }
}