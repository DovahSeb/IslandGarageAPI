using IslandGarageAPI.Application.DTOs;
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
        [Route("GetAllCustomers")]
        public async Task<ActionResult<List<CustomerResponse>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();

            return Ok(customers);
        }

        [HttpGet]
        [Route("GetCustomerById/{id}")]
        public async Task<ActionResult<List<CustomerResponse>>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer is null)
            {
                return NotFound("Customer not found");
            }

            return Ok(customer);
        }

        [HttpPost]
        [Route("AddCustomer")]
        public async Task<ActionResult<List<CustomerResponse>>> AddCustomer(CreateCustomerRequest request)
        {
            var newCustomer = await _customerService.AddCustomer(request);
            return Ok(newCustomer);
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        public async Task<ActionResult<CustomerResponse>> UpdateCustomer(UpdateCustomerRequest request)
        {
            try
            {
                var existingCustomer = await _customerService.UpdateCustomer(request);
                return Ok(existingCustomer);
            }
            catch (Exception)
            {
                return NotFound("Customer not found");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CustomerResponse>>> DeleteCustomer(int id)
        {
            try
            {
                var response = await _customerService.DeleteCustomer(id);
                return Ok(response);
            }
            catch (Exception)
            {
                return NotFound("Customer not found");
            }
        }
    }
}
