using AspNet1.Database;
using AspNet1.Database.Entities;
using AspNet1.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace AspNet1.Services.Implementations;

public class PizzaService(AppDbContext db) : IPizzaService
{
    public async Task<List<Pizza>> GetAllAsync()
    {
        //AsNoTracking - просто віддає дані і ef core байдуже що буде з ними, швидше ніж просто .ToListAsync()
        return await db.Pizzas.AsNoTracking().ToListAsync();
    }

    public async Task<Pizza?> GetByIdAsync(Guid id)
    { 
        return await db.Pizzas.FindAsync(id);
    }

    public async Task AddAsync(Pizza pizza)
    {
        pizza.Id = Guid.NewGuid();
        await db.Pizzas.AddAsync(pizza);
        await db.SaveChangesAsync(); 
    }

    public async Task UpdateAsync(Guid id, Pizza updatedPizza)
    {
        var existingPizza = await db.Pizzas.FindAsync(id);
        
        if (existingPizza is not null)
        {
            existingPizza.Name = updatedPizza.Name;
            existingPizza.Description = updatedPizza.Description;
            existingPizza.Price = updatedPizza.Price;

            await db.SaveChangesAsync();
        }
    }

    public async Task UpdatePriceAsync(Guid id, decimal newPrice)
    {
        //Оновлюємо тільки ціну і одразу зберігаємо в бд не виконуючи лишні запити
        await db.Pizzas
            .Where(p => p.Id == id)   
            .ExecuteUpdateAsync(setters => setters.SetProperty(p => p.Price, newPrice));
    }

    public async Task DeleteAsync(Guid id)
    {
        //ExecuteDeleteAsync - видалення одразу, не роблячи додатково запити в бд, такі як пошук та збереження змін
        await db.Pizzas.Where(p => p.Id == id).ExecuteDeleteAsync();
    }
}