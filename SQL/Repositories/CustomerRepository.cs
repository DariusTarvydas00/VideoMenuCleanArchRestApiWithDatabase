using System.Collections.Generic;
using VideoMenuConsoleApp.Core.DomainService;
using VideoMenuConsoleApp.Core.Entity;

namespace SQL.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        
        private readonly VideoMenuDbContext _ctx;

        public CustomerRepository(VideoMenuDbContext ctx)
        {
            _ctx = ctx;
        }
        public Customer Create(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public Customer ReadById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Customer> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public Customer Update(Customer customerUpdate)
        {
            throw new System.NotImplementedException();
        }

        public Customer Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Customer ReadByIdIncludeVideos(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}