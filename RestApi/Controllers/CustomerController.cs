using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VideoMenuConsoleApp.Core.ApplicationService;
using VideoMenuConsoleApp.Core.Entity;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return _customerService.GetAllCustomers();
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            try
            {
                return Ok(_customerService.FindCustomerByIdIncludeOrders(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            if (string.IsNullOrEmpty(customer.FirstName) || string.IsNullOrEmpty(customer.LastName) || string.IsNullOrEmpty(customer.Address) 
                || string.IsNullOrEmpty(customer.Email) || customer.PhoneNumber == null || customer.Birthday.Equals(null))
            {
                return BadRequest("Some fields are entered incorrectly");
            }

            return Ok(_customerService.CreateCustomer(customer));
        }

        [HttpPut]
        public ActionResult<Customer> Put(int id, [FromBody] Customer customer)
        {
            if (id < 1 || id != customer.Id)
            {
                return BadRequest("Something went wrong");
            }

            return Ok(_customerService.UpdateCustomer(customer));
        }

        [HttpDelete]
        public ActionResult<Customer> Delete(int id)
        {
            var customer = _customerService.DeleteCustomer(id);
            if (customer == null)
            {
                return StatusCode(404, "Did not found any Customer");
            }

            return Ok("Customer was deleted");
        }
    }
}