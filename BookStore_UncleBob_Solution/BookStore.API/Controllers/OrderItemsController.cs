using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Application.DTOs;
using BookStore.Application.Services;

[ApiController]
[Route("api/[controller]")]
public class OrderItemsController : ControllerBase
{
    private readonly IOrderItemService _orderItemService;

    public OrderItemsController(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }

    [HttpGet("order/{orderId}")]
    public async Task<ActionResult<IEnumerable<OrderItemDto>>> GetItemsByOrderId(int orderId)
    {
        var items = await _orderItemService.GetItemsByOrderIdAsync(orderId);
        return Ok(items);
    }

    [HttpGet("{orderItemId}")]
    public async Task<ActionResult<OrderItemDto>> GetOrderItem(int orderItemId)
    {
        var item = await _orderItemService.GetOrderItemByIdAsync(orderItemId);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult> CreateOrderItem([FromBody] OrderItemDto orderItemDto)
    {
        if (orderItemDto == null)
        {
            return BadRequest();
        }
        await _orderItemService.AddOrderItemAsync(orderItemDto);
        return CreatedAtAction(nameof(GetOrderItem), new { orderItemId = orderItemDto.OrderItemId }, orderItemDto);
    }

    [HttpPut("{orderItemId}")]
    public async Task<ActionResult> UpdateOrderItem(int orderItemId, [FromBody] OrderItemDto orderItemDto)
    {
        if (orderItemId != orderItemDto.OrderItemId)
        {
            return BadRequest();
        }
        await _orderItemService.UpdateOrderItemAsync(orderItemDto);
        return NoContent();
    }

    [HttpDelete("{orderItemId}")]
    public async Task<ActionResult> DeleteOrderItem(int orderItemId)
    {
        await _orderItemService.DeleteOrderItemAsync(orderItemId);
        return NoContent();
    }
}
