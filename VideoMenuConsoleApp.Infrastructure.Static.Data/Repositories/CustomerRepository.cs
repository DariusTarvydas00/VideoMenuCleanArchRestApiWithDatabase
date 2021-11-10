using System;
using System.Collections.Generic;
using VideoMenuConsoleApp.Core.DomainService;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenuConsoleApp.Infrastructure.Static.Data.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {

        public CustomerRepository()
        {
            if (FakeDB.Customers.Count >= 1) return;
            Customer cust1 = new Customer()
            {
                Id = FakeDB.customerId++,
                FirstName = "Darius",
                LastName = "Tarvydas",
                Birthday = new DateTime(1990, 05, 06),
                Email = "tarvydasdarius@gmail.com",
                PhoneNumber = 86967868
            };
            Customer cust2 = new Customer()
            {
                Id = FakeDB.customerId++,
                FirstName = "Vytenis",
                LastName = "Urbonas",
                Birthday = new DateTime(1991, 09, 30),
                Email = "vytenisurbonas@gmail.com",
                PhoneNumber = 86967869
            };
            FakeDB.Customers.Add(cust1);
            FakeDB.Customers.Add(cust2);
        }

        public Customer Create(Customer customer)
        {
            customer.Id = FakeDB.customerId++;
            FakeDB.Customers.Add(customer);
            return customer;
        }

        public Customer ReadById(int id)
        {
            foreach (var customer in FakeDB.Customers)
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
            return FakeDB.Customers;
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
                FakeDB.Customers.Remove(customerFound);
                return customerFound;
            }

            return null;
        }
    }
}