using CustomerAPI.Models;
using CustomerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public ActionResult<Customer> Get(Customer cust)
        {

            var customer = _customerService.Get(cust.username);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpPost]
        public ActionResult<Customer> Create(Customer customer)
        {
            _customerService.Create(customer);

            return CreatedAtRoute("Getcustomer", new { id = customer.Id.ToString() }, customer);
        }

        [HttpPost]

        public IActionResult Update(Customer cust)
        {
            var customer = _customerService.Get(cust.username);

            if (customer == null || (customer.credit_limit - customer.balance) < cust.balance)
            {
                return NotFound();
            }

            _customerService.Update(cust.username, customer.balance + cust.balance);

            return NoContent();
        }

        [HttpPost]
        public IActionResult Delete(Customer cust)
        {
            var customer = _customerService.Get(cust.username);

            if (customer == null)
            {
                return NotFound();
            }

            _customerService.Remove(customer.username);

            return NoContent();
        }

    }
}
