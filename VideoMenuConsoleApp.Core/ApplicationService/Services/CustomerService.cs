using System;
using System.Collections.Generic;
using System.Linq;
using VideoMenuConsoleApp.Core.DomainService;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenuConsoleApp.Core.ApplicationService.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IVideoRepository _videoRepository;

        public CustomerService(ICustomerRepository customerRepository, IVideoRepository videoRepository)
        {
            _customerRepo = customerRepository;
            _videoRepository = videoRepository;
        }

        public Customer NewCustomer(string firstName, string lastName, int phoneNumber, string emailAddress, DateTime dateOfBirth, string address)
        {
            var cust = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Email = emailAddress,
                Birthday = dateOfBirth,
                Address = address
            };
            return cust;
        }

        public Customer CreateCustomer(Customer customer)
        {
            return _customerRepo.Create(customer);
        }

        public Customer UpdateCustomer(Customer customerUpdate)
        {
            var customer = FindCustomerById(customerUpdate.Id);
            customer.FirstName = customerUpdate.FirstName;
            customer.LastName = customerUpdate.LastName;
            customer.Birthday = customerUpdate.Birthday;
            customer.Email = customerUpdate.Email;
            customer.PhoneNumber = customerUpdate.PhoneNumber;
            customer.Address = customerUpdate.Address;
            return customer;
        }

        public Customer DeleteCustomer(int id)
        {
            return _customerRepo.Delete(id);
        }

        public Customer FindCustomerById(int id)
        {
            return _customerRepo.ReadById(id);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepo.ReadAll().ToList();
        }

        public List<Customer> GetAllByFirstName(string name)
        {
            var list = _customerRepo.ReadAll();
            var queryContinued = list.Where(customer => customer.FirstName.Equals(name));
            queryContinued.OrderBy(customer => customer.FirstName);
            return queryContinued.ToList();
        }

        public Customer FindCustomerByIdIncludeOrders(int id)
        {
            var customer = _customerRepo.ReadById(id);
            customer.Videos = _videoRepository.ReadAll().Where(video => video.Customer.Id == id).ToList();
            return customer;
        }
    }
}