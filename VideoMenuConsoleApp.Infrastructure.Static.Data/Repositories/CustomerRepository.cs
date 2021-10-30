using System;
using System.Collections.Generic;
using VideoMenuConsoleApp.Core.DomainService;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenuConsoleApp.Infrastructure.Static.Data.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private int _customerId = 1;
        private List<Customer> _customers = new List<Customer>();
        
        public Customer Create(Customer customer)
        {
            customer.Id = _customerId++;
            _customers.Add(customer);
            return customer;
        }

        public Customer ReadById(int id)
        {
            foreach (var customer in _customers)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }

            return null;
        }

        public IEnumerable<Customer> ReadAll()
        {
            return _customers;
        }

        public Customer Update(Customer customerUpdate)
        {
            var customerFromDb = this.ReadById(customerUpdate.Id);
            if (customerFromDb != null)
            {
                customerFromDb.FirstName = customerUpdate.FirstName;
                customerFromDb.LastName = customerUpdate.LastName;
                customerFromDb.Birthday = customerUpdate.Birthday;
                customerFromDb.PhoneNumber = customerUpdate.PhoneNumber;
                customerFromDb.Email = customerUpdate.Email;
                customerFromDb.Address = customerUpdate.Address;
                return customerFromDb;
            }

            return null;
        }

        public Customer Delete(int id)
        {
            var customerFound = this.ReadById(id);
            if (customerFound != null)
            {
                _customers.Remove(customerFound);
                return customerFound;
            }

            return null;
        }
    }
}