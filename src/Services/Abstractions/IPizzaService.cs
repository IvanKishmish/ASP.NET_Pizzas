using AspNet1.Database.Entities;

namespace AspNet1.Services.Abstractions;

public interface IPizzaService
{
     Task<List<Pizza>> GetAllAsync();
     Task<Pizza?>  GetByIdAsync(Guid id);
     Task AddAsync(Pizza pizza);
     Task UpdateAsync(Guid id, Pizza updatedPizza);
     Task UpdatePriceAsync(Guid id, decimal newPrice);
     Task DeleteAsync(Guid id);
}