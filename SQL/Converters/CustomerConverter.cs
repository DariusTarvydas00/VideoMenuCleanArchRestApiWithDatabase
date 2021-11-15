using SQL.Entities;
using VideoMenuConsoleApp.Core.Entity;

namespace SQL.Converters
{
    public class CustomerConverter
    {
        public Customer Convert(CustomerEntity entity)
        {
            return new Customer
            {
                Id = entity.Id,
                Address = entity.Address,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PhoneNumber = entity.PhoneNumber,
                Birthday = entity.Birthday,
            };
        }
        
        public CustomerEntity Convert(Customer customer)
        {
            return new CustomerEntity
            {
                Id = customer.Id,
                Address = customer.Address,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Birthday = customer.Birthday,
                VideoId = customer.Videos != null ? customer.Videos.Count : 0
            };
        }
    }
}