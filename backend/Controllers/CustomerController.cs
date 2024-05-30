using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly CMSDBContext _DBContext;

        public CustomerController(CMSDBContext dbContext)
        {
            this._DBContext = dbContext;
        }

        [HttpGet("GetAll")]
        [Authorize]
        public IActionResult GetAll()
        {
            var customers = this._DBContext.Customers.ToList();
            return Ok(customers);
        }

        [HttpGet("GetById/{id}")]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        public IActionResult Create([FromBody] backend.Models.Customers _customer)
        {
            try
            {
                this._DBContext.Customers.Add(_customer);
                this._DBContext.SaveChanges();
                return Ok(true);
            }
            catch (DbUpdateException)
            {
                return BadRequest("Email address is already in use.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut("Update/{id}")]
        [Authorize]
        public IActionResult Update([FromBody] backend.Models.Customers _customer, int id)
        {
            try
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
            catch (DbUpdateException)
            {
                return BadRequest("Email address is already in use.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
