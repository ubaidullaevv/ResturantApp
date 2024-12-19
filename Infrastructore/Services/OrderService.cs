using Domain.Models;
using Infrastructore.Context;
using Infrastructore.Interfaces;
using Infrastructore.ApiResponse;
using Npgsql; 
using Dapper;
using System.Net;

namespace Services;

public class OrderService(DapperContext _context) : IOrderService
{
    public async Task<Response<bool>> AddOrder(Order Order)
    {
        using var context=_context.Connection();
        string cmd="insert into Orders(customerid,tableid,status)values(@CustomerId,@TableId,@Status)";
        var res=await context.ExecuteAsync(cmd,Order);
        if(res==0) return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        return new Response<bool>(res>0);
    }

    public async Task<Response<bool>> UpdateOrdersStatus(int orderid)
    {
         using var context=_context.Connection();
        string cmd="update orders set status='Waiting' where OrderId=@OrderId";
        var res=await context.ExecuteAsync(cmd,new {OrderId=orderid});
        if(res==0) return new Response<bool>(HttpStatusCode.NotFound,"Cannot found order!");
        return new Response<bool>(res>0);
    }

    public async Task<Response<List<Order>>> GetOrders()
    {
        using var context=_context.Connection();
        string cmd="select * from Orders";
        var res=(await context.QueryAsync<Order>(cmd)).ToList();
        if(res==null) return new Response<List<Order>>(HttpStatusCode.NotFound,"Client Eror!");
        return new Response<List<Order>>(res);
    }

    public async Task<Response<List<Order>>> GetCustomerOrders(int customerid)
    {
        using var context=_context.Connection();
        string cmd="select * from Orders where CustomerId=@CustomerId";
        var res=(await context.QueryAsync<Order>(cmd,new {CustomerId=customerid})).ToList();
        if(res==null) return new Response<List<Order>>(HttpStatusCode.NotFound,"Client Eror!");
        return new Response<List<Order>>(res); 
    }

    public async Task<Response<List<Order>>> GetOredersByStatus()
    {
         using var context=_context.Connection();
        string cmd="select * from Orders where Status='Waiting' or Status='waiting;";
        var res=(await context.QueryAsync<Order>(cmd)).ToList();
        if(res==null) return new Response<List<Order>>(HttpStatusCode.NotFound,"Client Eror!");
        return new Response<List<Order>>(res); 
    }
}