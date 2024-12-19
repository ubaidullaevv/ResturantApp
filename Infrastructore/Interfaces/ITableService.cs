using Domain.Models;
using Infrastructore.ApiResponse;
using System.Net;
namespace Infrastructore.Interfaces;





public interface ITableService
{
    public Task<Response<List<Table>>> GetTables();
    public Task<Response<bool>> BookTable(int tableid);
    public Task<Response<bool>> FreeTable(int tableid);
    public Task<Response<List<Table>>> GetFreeables();
    public Task<Response<bool>> UpdateTable(Table table);
}