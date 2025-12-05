using MVC_AtmApp.Models;

namespace MVC_AtmApp.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetWithTransactionsAsync(int id);
        Task<Customer> GetByAccountNumberAsync(string accountNumber);
    }
}
