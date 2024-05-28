using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CMSDBContext _DBContext;

        public CustomerController(CMSDBContext dbContext)
        {
            this._DBContext = dbContext;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var customers = this._DBContext.Customers.ToList();
            return Ok(customers);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var customer = this._DBContext.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer != null)
            {
                return Ok(customer);
            }
            return Ok(false);
        }

        [HttpDelete("Remove/{id}")]
        public IActionResult Remove(int id)
        {
            var customer = this._DBContext.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer != null)
            {
                this._DBContext.Remove(customer);
                this._DBContext.SaveChanges();
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] backend.Models.Customers _customer)
        {
            this._DBContext.Customers.Add(_customer);
            this._DBContext.SaveChanges();
            return Ok(true);
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update([FromBody] backend.Models.Customers _customer, int id)
        {
            var customer = this._DBContext.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer != null)
            {
                customer.FirstName = _customer.FirstName;
                customer.LastName = _customer.LastName;
                customer.Email = _customer.Email;
                customer.Phone = _customer.Phone;
                customer.Address = _customer.Address;
                this._DBContext.SaveChanges();
                return Ok(true);
            }
            return Ok(false);
        }
    }
}
