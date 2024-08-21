using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IMapper _mapper;

    public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
    {
        _orderItemRepository = orderItemRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderItemDto>> GetItemsByOrderIdAsync(int orderId)
    {
        var orderItems = await _orderItemRepository.GetItemsByOrderIdAsync(orderId);
        return _mapper.Map<IEnumerable<OrderItemDto>>(orderItems);
    }

    public async Task<OrderItemDto> GetOrderItemByIdAsync(int orderItemId)
    {
        var orderItem = await _orderItemRepository.GetByIdAsync(orderItemId);
        return _mapper.Map<OrderItemDto>(orderItem);
    }

    public async Task AddOrderItemAsync(OrderItemDto orderItemDto)
    {
        var orderItem = _mapper.Map<OrderItem>(orderItemDto);
        await _orderItemRepository.AddAsync(orderItem);
    }

    public async Task UpdateOrderItemAsync(OrderItemDto orderItemDto)
    {
        var orderItem = _mapper.Map<OrderItem>(orderItemDto);
        await _orderItemRepository.UpdateAsync(orderItem);
    }

    public async Task DeleteOrderItemAsync(int orderItemId)
    {
        await _orderItemRepository.DeleteAsync(orderItemId);
    }
}
