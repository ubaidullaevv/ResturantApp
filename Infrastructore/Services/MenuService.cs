using Domain.Models;
using Infrastructore.Context;
using Infrastructore.Interfaces;
using Infrastructore.ApiResponse;
using Npgsql; 
using Dapper;
using System.Net;

namespace Services;

public class MenuItemService(DapperContext _context) : IMenuItemService
{
    public async Task<Response<bool>> AddMenuItem(MenuItem menuItem)
    {
        using var context=_context.Connection();
        string cmd="insert into MenuItems(name,price,category)values(@Name,@Price,@Category)";
        var res=await context.ExecuteAsync(cmd,menuItem);
        if(res==0) return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        return new Response<bool>(res>0);
    }


    public async Task<Response<List<MenuItem>>> GetMenuItems()
    {
        using var context=_context.Connection();
        string cmd="select * from MenuItems";
        var res=(await context.QueryAsync<MenuItem>(cmd)).ToList();
        if(res==null) return new Response<List<MenuItem>>(HttpStatusCode.InternalServerError,"Server Eror!");
        return new Response<List<MenuItem>>(res);
    }
}