using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Orders.Models;

namespace Orders.Services
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int id);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<List<Customer>> GetCustomersAsync();
    }

    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers;

        public CustomerService()
        {
            this._customers = new List<Customer>()
            {
                new Customer(1, "Natasha Romanoff"),
                new Customer(2, "Carol Danvers"),
                new Customer(3, "Jean Grey"),
                new Customer(4, "Wanda Maximoff"),
                new Customer(5, "Gamora"),
            };
        }

        public Customer GetCustomerById(int id)
        {
            return this.GetCustomerByIdAsync(id).Result;
        }

        public Task<Customer> GetCustomerByIdAsync(int id)
        {
            return Task.FromResult(this._customers.SingleOrDefault(p => p.Id.Equals(id)));
        }

        public Task<List<Customer>> GetCustomersAsync()
        {
            return Task.FromResult(this._customers);
        }
    }
}