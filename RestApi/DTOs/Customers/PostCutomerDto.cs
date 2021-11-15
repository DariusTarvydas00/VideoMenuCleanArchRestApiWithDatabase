using System;

namespace RestApi.DTOs.Customers
{
    public class PostCutomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public int VideoEntityId { get; set; }
    }
}