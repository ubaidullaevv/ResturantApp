using Domain.Models;
using Infrastructore.Context;
using Infrastructore.Interfaces;
using Infrastructore.ApiResponse;
using Npgsql; 
using Dapper;
using System.Net;

namespace Services;

public class CustomerService(DapperContext _context) : ICustomerService
{
    public async Task<Response<bool>> AddCustomer(Customer customer)
    {
        using var context=_context.Connection();
        string cmd="insert into Customers(name,phone)values(@Name,@Phone)";
        var res=await context.ExecuteAsync(cmd,customer);
        if(res==0) return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        return new Response<bool>(res>0);
    }

    public async Task<Response<bool>> DeleteCustomer(int id)
    {
        using var context=_context.Connection();
        string cmd="delete from customers where customerid=@CustomerId";
        var res=await context.ExecuteAsync(cmd,new {customerid=id});
        if(res==0) return new Response<bool>(HttpStatusCode.NotFound,"Cannot found customer!");
        return new Response<bool>(res>0);
    }

    public async Task<Response<List<Customer>>> GetCustomerByName(string name)
    {
        using var context=_context.Connection();
        string cmd="select * from customers where Name=@Name";
        var res=(await context.QueryAsync<Customer>(cmd,new {Name=name})).ToList();
        if(res==null)return new Response<List<Customer>>(HttpStatusCode.InternalServerError,"Server eror!");
        return new Response<List<Customer>>(res);
    }

    public async Task<Response<Customer>> GetCustomerByPhone(string phone)
    {
         using var context=_context.Connection();
        string cmd="select * from customers where Phone=@Phone";
        var res=await context.QueryFirstOrDefaultAsync<Customer>(cmd,new {Phone=phone});
        if(res==null) return new Response<Customer>(HttpStatusCode.NotFound,"Client Eror!");
        return new Response<Customer>(res);
    }

    public async Task<Response<List<Customer>>> GetCustomers()
    {
        using var context=_context.Connection();
        string cmd="select * from customers";
        var res=(await context.QueryAsync<Customer>(cmd)).ToList();
        if(res==null) return new Response<List<Customer>>(HttpStatusCode.NotFound,"Client Eror!");
        return new Response<List<Customer>>(res);
    }
}