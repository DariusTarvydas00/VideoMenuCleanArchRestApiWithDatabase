using System.Collections.Generic;
using System.Linq;
using VideoMenuConsoleApp.Core.DomainService;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenu.Infrastructure.Data.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly VideoMenuAppContext _ctx;

        public CustomerRepository(VideoMenuAppContext ctx)
        {
            _ctx = ctx;
        }

        public Customer Create(Customer customer)
        {
            var cust = _ctx.Customers.Add(customer).Entity;
            _ctx.SaveChanges();
            return cust;
        }

        public Customer ReadById(int id)
        {
            return _ctx.Customers.FirstOrDefault(customer => customer.Id == id);
        }

        public IEnumerable<Customer> ReadAll()
        {
            return _ctx.Customers;
        }

        public Customer Update(Customer customerUpdate)
        {
            throw new System.NotImplementedException();
        }

        public Customer Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}