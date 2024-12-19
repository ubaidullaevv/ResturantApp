using Domain.Models;
using Infrastructore.ApiResponse;
using System.Net;
namespace Infrastructore.Interfaces;





public interface IOrderService
{
    public Task<Response<List<Order>>> GetOrders();
    public Task<Response<bool>> AddOrder(Order Order);
    public Task<Response<bool>> UpdateOrdersStatus(int orderid);
    public Task<Response<List<Order>>> GetCustomerOrders(int customerid);
    public Task<Response<List<Order>>> GetOredersByStatus();
}