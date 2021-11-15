using System.Collections.Generic;
using System.Linq;
using SQL.Entities;
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
            var entity = _ctx.Customers.Add(new CustomerEntity()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Birthday = customer.Birthday,
                Address = customer.Address,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            }).Entity;
            _ctx.SaveChanges();
            return new Customer()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Birthday = entity.Birthday,
                Address = entity.Address,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber
            };
        }

        public Customer ReadById(int id)
        {
            var entity = _ctx.Customers.FirstOrDefault(customerEntity => customerEntity.Id == id);
            return new Customer() {Id = entity.Id};
        }

        public IEnumerable<Customer> ReadAll()
        {
            return _ctx.Customers.Select(customerEntity => new Customer()
            {
                Id = customerEntity.Id,
                FirstName = customerEntity.FirstName,
                LastName = customerEntity.LastName,
                Birthday = customerEntity.Birthday,
                Address = customerEntity.Address,
                Email = customerEntity.Email,
                PhoneNumber = customerEntity.PhoneNumber
            }).ToList();
        }

        public Customer Update(Customer customerUpdate)
        {
            var entity = _ctx.Customers.Update(new CustomerEntity()
            {
                Id = customerUpdate.Id,
                FirstName = customerUpdate.FirstName,
                LastName = customerUpdate.LastName,
                Birthday = customerUpdate.Birthday,
                Address = customerUpdate.Address,
                Email = customerUpdate.Email,
                PhoneNumber = customerUpdate.PhoneNumber
            }).Entity;
            _ctx.SaveChanges();
            return new Customer()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Birthday = entity.Birthday,
                Address = entity.Address,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber
            };
        }

        public Customer Delete(int id)
        {
            var entity = _ctx.Customers.Remove(new CustomerEntity() {Id = id}).Entity;
            _ctx.SaveChanges();
            return new Customer() {Id = entity.Id};
        }

        public IEnumerable<Customer> ReadByIdIncludeVideos(int id)
        {
            var entity = _ctx.Customers.Select(customerEntity => new Customer() {Id = id}).Where(customer => customer.VideosId == id);
            return entity;
        }
    }
}