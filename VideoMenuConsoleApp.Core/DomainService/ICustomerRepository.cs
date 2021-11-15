using System.Collections.Generic;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenuConsoleApp.Core.DomainService
{
    public interface ICustomerRepository
    {
        Customer Create(Customer customer);
        Customer ReadById(int id);
        IEnumerable<Customer> ReadAll();
        Customer Update(Customer customerUpdate);
        Customer Delete(int id);
        IEnumerable<Customer> ReadByIdIncludeVideos(int id);
    }
}