using Domain.Models;
using Infrastructore.Context;
using Infrastructore.Interfaces;
using Infrastructore.ApiResponse;
using Npgsql; 
using Dapper;
using System.Net;

namespace Services;

public class TableService(DapperContext _context) : ITableService
{
    public async Task<Response<bool>> BookTable(int tableid)
    {
        using var context=_context.Connection();
        string cmd="update tables set IsOccupied='false' where TableId=@TableId";
        var res=await context.ExecuteAsync(cmd,new {TableId=tableid});
        if(res==0) return new Response<bool>(HttpStatusCode.InternalServerError,"Cannot change status!");
        return new Response<bool>(res>0);
    }

    public async Task<Response<bool>> FreeTable(int tableid)
    {
        using var context=_context.Connection();
        string cmd="update tables set IsOccupied='true' where TableId=@TableId";
        var res=await context.ExecuteAsync(cmd,new {TableId=tableid});
        if(res==0) return new Response<bool>(HttpStatusCode.InternalServerError,"Cannot change status!");
        return new Response<bool>(res>0);
    }

    public async Task<Response<List<Table>>> GetFreeables()
    {
         using var context=_context.Connection();
        string cmd="select * from Tables where IsOccopied='true'";
        var res=(await context.QueryAsync<Table>(cmd)).ToList();
        if(res==null) return new Response<List<Table>>(HttpStatusCode.NotFound,"Client Eror!");
        return new Response<List<Table>>(res);
    }

    public async Task<Response<List<Table>>> GetTables()
    {
        using var context=_context.Connection();
        string cmd="select * from Tables";
        var res=(await context.QueryAsync<Table>(cmd)).ToList();
        if(res==null) return new Response<List<Table>>(HttpStatusCode.NotFound,"Client Eror!");
        return new Response<List<Table>>(res);
    }

    public async Task<Response<bool>> UpdateTable(Table table)
    {
      using var context=_context.Connection();
      string cmd="update tables set tableid=@TableId,tablenumber=@TableNumber,isoccopied=@IsOccopied";
      var res=await context.ExecuteAsync(cmd,table);
      if(res==0) return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
      return new Response<bool>(res>0);
    }
}