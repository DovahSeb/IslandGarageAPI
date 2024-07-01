using IslandGarageAPI.Application.Interfaces;
using IslandGarageAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IslandGarageAPI.Controllers
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
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Customer>>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer is null)
            {
                return NotFound("Customer not found");
            }

            return Ok(customer);
        }
    }
}
