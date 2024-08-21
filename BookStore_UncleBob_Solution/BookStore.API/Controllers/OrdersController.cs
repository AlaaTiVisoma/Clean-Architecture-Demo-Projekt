using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByUserId(int userId)
    {
        var orders = await _orderService.GetOrdersByUserIdAsync(userId);
        return Ok(orders);
    }

    [HttpGet("{orderId}")]
    public async Task<ActionResult<OrderDto>> GetOrder(int orderId)
    {
        var order = await _orderService.GetOrderByIdAsync(orderId);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult> CreateOrder([FromBody] OrderDto orderDto)
    {
        if (orderDto == null)
        {
            return BadRequest();
        }
        await _orderService.AddOrderAsync(orderDto);
        return CreatedAtAction(nameof(GetOrder), new { orderId = orderDto.OrderId }, orderDto);
    }

    [HttpPut("{orderId}")]
    public async Task<ActionResult> UpdateOrder(int orderId, [FromBody] OrderDto orderDto)
    {
        if (orderId != orderDto.OrderId)
        {
            return BadRequest();
        }
        await _orderService.UpdateOrderAsync(orderDto);
        return NoContent();
    }

    [HttpDelete("{orderId}")]
    public async Task<ActionResult> DeleteOrder(int orderId)
    {
        await _orderService.DeleteOrderAsync(orderId);
        return NoContent();
    }
}
