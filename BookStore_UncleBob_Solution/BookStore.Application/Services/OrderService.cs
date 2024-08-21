using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(int userId)
    {
        var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<OrderDto> GetOrderByIdAsync(int orderId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        return _mapper.Map<OrderDto>(order);
    }

    public async Task AddOrderAsync(OrderDto orderDto)
    {
        var order = _mapper.Map<Order>(orderDto);
        await _orderRepository.AddAsync(order);
    }

    public async Task UpdateOrderAsync(OrderDto orderDto)
    {
        var order = _mapper.Map<Order>(orderDto);
        await _orderRepository.UpdateAsync(order);
    }

    public async Task DeleteOrderAsync(int orderId)
    {
        await _orderRepository.DeleteAsync(orderId);
    }
}
