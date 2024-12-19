using Domain.Models;
using Infrastructore.ApiResponse;
using System.Net;
namespace Infrastructore.Interfaces;





public interface ICustomerService
{
    public Task<Response<List<Customer>>> GetCustomers();
    public Task<Response<bool>> AddCustomer(Customer customer);
    public Task<Response<Customer>> GetCustomerByPhone(string phone);
    public Task<Response<List<Customer>>> GetCustomerByName(string name);
    public Task<Response<bool>> DeleteCustomer(int id);
}