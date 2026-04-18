using AspNet1.Database.Entities;
using AspNet1.Dtos;
using AspNet1.Dtos.Order;
using AspNet1.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AspNet1.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<OrderDto>>> GetAll()
    {
        var orders = await orderService.GetAllAsync();

        var dtos = orders.Select(o => new OrderDto(
            o.Id, 
            o.Title, 
            o.Description, 
            o.Pizza!.Name!, 
            o.Quantity, 
            o.TotalPrice,
            o.OrderDate
        )).ToList();

        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDto>> GetById(Guid id)
    {
        var order = await orderService.GetByIdAsync(id);
        if(order is null) return NotFound();
        
        return Ok(new OrderDto(order.Id,  order.Title, order.Description,  order.Pizza!.Name!, order.Quantity, order.TotalPrice,  order.OrderDate));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderDto orderDto)
    {
        var order = new Order
        {
            Title = orderDto.Title,
            Description = orderDto.Description,
            Quantity = orderDto.Quantity,
            ClientEmail = orderDto.ClientEmail,
            PizzaId = orderDto.PizzaId
        };
    
        await orderService.AddAsync(order);
        
        var savedOrder = await orderService.GetByIdAsync(order.Id);

        var response = new OrderDto(
            savedOrder!.Id, 
            savedOrder.Title, 
            savedOrder.Description, 
            savedOrder.Pizza!.Name!, 
            savedOrder.Quantity,
            savedOrder.TotalPrice,
            savedOrder.OrderDate);
    
        return CreatedAtAction(nameof(GetById), new { id = savedOrder.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateOrderDto updatedOrderDto)
    {
        var existingOrder = await orderService.GetByIdAsync(id);
        
        if(existingOrder is null) return NotFound();
        
        await orderService.UpdateAsync(id, updatedOrderDto);
        
        return NoContent();
    }

    [HttpPatch("{id}/price")]
    public async Task<IActionResult> UpdatePrice(Guid id, decimal newPrice)
    {
        var existingOrder = await orderService.GetByIdAsync(id);
        
        if(existingOrder is null) return NotFound();
        
        await orderService.UpdatePriceAsync(id, newPrice);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await orderService.DeleteAsync(id);
        return NoContent();
    }
}