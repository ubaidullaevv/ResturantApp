using Domain.Models;
using Infrastructore.ApiResponse;
using System.Net;
namespace Infrastructore.Interfaces;





public interface IMenuItemService
{
    public Task<Response<List<MenuItem>>> GetMenuItems();
    public Task<Response<bool>> AddMenuItem(MenuItem menuItem);
}