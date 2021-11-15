using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestApi.DTOs.Customers;
using RestApi.DTOs.Videos;
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
        public ActionResult<List<Customer>> Get()
        {
            try
            {
                return Ok(_customerService.GetAllCustomers());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<GetCustomerByIdDto> Get(int id)
        {
            var videoFromDto = _customerService.FindCustomerById(id);
            return Ok(new GetCustomerByIdDto()
            {
                FirstName = videoFromDto.FirstName,
                LastName = videoFromDto.LastName,
                Address = videoFromDto.Address,
                Birthday = videoFromDto.Birthday,
                Email = videoFromDto.Email,
                PhoneNumber = videoFromDto.PhoneNumber
            });
        }

        [HttpPost]
        public ActionResult<PostVideoDto> Post([FromBody] Customer customer)
        {
            var customerDto = new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Birthday = customer.Birthday,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            };
            try
            {
                var newCustomer = _customerService.CreateCustomer(customerDto);
                return Created($"https://localhost:5001/api/videos/{customerDto.Id}", customerDto);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public ActionResult<PutVideoDto> Put(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest("Something went wrong");
            }

            return Ok(_customerService.UpdateCustomer(new Customer()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Birthday = customer.Birthday,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            }));
        }

        [HttpDelete]
        public ActionResult<GetCustomerByIdDto> Delete(int id)
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