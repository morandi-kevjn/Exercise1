using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http; // add ep65
using Exercise1.Dtos; // add ep68
using AutoMapper; // add ep68

// created in ep65

namespace Exercise1.Controllers.Api
{
    public class CustomersController : ApiController
    {
        // ep65 <<<
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        // public IEnumerable<Customer> GetCustomers() customerDto in ep68
        public IEnumerable<CustomerDto> GetCustomers()
        {
            // return _context.Customers.ToList(); ep68
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        // GET /api/customers/1
        // public Customer GetCustomer(int id) ep68
        // ep70
        // public CustomerDto GetCustomer(int id)
        public IHttpActionResult GetCustomer(int id)
        { 
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();
            // ep70
            // throw new HttpResponseException(HttpStatusCode.NotFound);

            // return customer; ep68
            // return Mapper.Map<Customer, CustomerDto>(customer); ep70
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customers
        // public Customer CreateCustomer(Customer customer) ep68
        // ep70
        // public CustomerDto CreateCustomer(CustomerDto customerDto)
        [HttpPost] // if I don't use this, I had to rename the method in PostCustomer -> Microsoft system
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(); // ep70
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                

            // ep68
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            
            _context.Customers.Add(customer);
            _context.SaveChanges();

            // ep68
            customerDto.Id = customer.Id;

            // return customerDto;
            // ep70
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT /api/customers/1
        // I can return void or a customer
        // public void UpdateCustomer(int id, Customer customer) ep68
        // public void UpdateCustomer(int id, CustomerDto customerDto) // test5
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(); // test5
                // throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound(); // test5
                // throw new HttpResponseException(HttpStatusCode.NotFound);

            // ep 68
            // Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);
            Mapper.Map(customerDto, customerInDb); // easier solution

            /* it not neccessary anymore ep68
             * customerInDb.Name = customerDto.Name;
             * customerInDb.BirthDate = customerDto.BirthDate;
             * customerInDb.IsSubscribedToNewsLetter = customerInDb.IsSubscribedToNewsLetter; // before I saved in Customer and not in CustomerInDb, it was an error fix ep68
             * customerInDb.MembershipTypeId = customerDto.MembershipTypeId; // same as the code before
            */

            _context.SaveChanges();

            // test 5
            return Ok();
        }

        // DELETE /api/customers/1
        // public void DeleteCustomer(int id) test5
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();
                // throw new HttpResponseException(HttpStatusCode.NotFound); test5

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            // test5
            return Ok();
        }

        // >>>

    }
}
