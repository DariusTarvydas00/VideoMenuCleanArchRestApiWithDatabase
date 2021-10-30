using System;
using System.Collections.Generic;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenuConsoleApp.Core.ApplicationService
{
    public interface ICustomerService
    {
        // Just New Customer
        Customer NewCustomer(string firstName, string lastName, int phoneNumber, string emailAddress, DateTime dateOfBirth, string address); //not saving any date just creating instance // less hiding option
       
        //This is CRUD
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customerUpdate);
        Customer DeleteCustomer(int id);
        Customer FindCustomerById(int id);
        List<Customer> GetAllCustomers();
        List<Customer> GetAllByFirstName(string name);
    }
}