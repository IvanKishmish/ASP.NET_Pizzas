using AspNet1.Database.Entities;
using AspNet1.Dtos;
using AspNet1.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AspNet1.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class PizzaController(IPizzaService pizzaService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<PizzaDto>>> GetAll()
    {
        var pizzas = await pizzaService.GetAllAsync();

        var dtos = pizzas.Select(p => new PizzaDto(p.Id, p.Name!, p.Description!, p.Price)).ToList();
        
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PizzaDto>> GetById(Guid id)
    {
        var pizza = await pizzaService.GetByIdAsync(id);
        if(pizza is null) return NotFound();

        return Ok(new PizzaDto(pizza.Id, pizza.Name!, pizza.Description!, pizza.Price));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreatePizzaDto pizzaDto)
    {
        var pizza = new Pizza
        {
            Name = pizzaDto.Name,
            Description = pizzaDto.Description,
            Price = (decimal)pizzaDto.Price!
        };
        
        await pizzaService.AddAsync(pizza);
        
        var response = new PizzaDto(pizza.Id, pizzaDto.Name, pizzaDto.Description, pizzaDto.Price);
        
        //повертаємо статус 201, вказуємо метод для отримання ресурсу (GetById) та передаємо створений об'єкт
        return CreatedAtAction(nameof(GetById), new { id = pizza.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Pizza pizza)
    {
        var existingPizza = await pizzaService.GetByIdAsync(id);
        
        if (existingPizza is null)
        {
            return NotFound();
        }
        
        await pizzaService.UpdateAsync(id, pizza);
        return NoContent();//204 for successful update
    }

    [HttpPatch("{id}/price")]
    public async Task<IActionResult> UpdatePrice(Guid id, decimal newPrice)
    {
        var existingPizza = await pizzaService.GetByIdAsync(id);
        
        if(existingPizza is null) return NotFound();
        
        await pizzaService.UpdatePriceAsync(id, newPrice);
        return NoContent();
    }   
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await pizzaService.DeleteAsync(id);
        return NoContent();
    }
}