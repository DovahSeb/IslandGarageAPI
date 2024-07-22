using IslandGarageAPI.Application.DTOs;
using IslandGarageAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IslandGarageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        [Route("GetVehicleById/{id}")]
        public async Task<ActionResult<VehicleImageResponse>> GetVehicleById(int id)
        {
            var vehicle = await _vehicleService.GetById(id);
            if(vehicle is null)
            {
                return NotFound("Vehicle not found");
            }

            return Ok(vehicle);
        }

        [HttpGet]
        [Route("GetVehicleByCustomerId/{customerId}")]
        public async Task<ActionResult<List<VehicleResponse>>> GetVehicleByCustomerId(int customerId)
        {
            var vehicles = await _vehicleService.GetVehicleByCustomerId(customerId);
            if (vehicles is null)
            {
                return NotFound("Vehicles not found");
            }

            return Ok(vehicles);
        }

        [HttpPost]
        [Route("AddVehicle")]
        public async Task<ActionResult<VehicleResponse>> AddCustomer(CreateVehicleRequest request)
        {
            var newVehicle = await _vehicleService.AddVehicle(request);
            return Ok(newVehicle);
        }

        [HttpPut]
        [Route("UpdateVehicle")]
        public async Task<ActionResult<VehicleResponse>> UpdateVehicle (UpdateVehicleRequest request)
        {
            try
            {
                var existingVehicle = await _vehicleService.UpdateVehicle(request);
                return Ok(existingVehicle);
            }
            catch (Exception)
            {
                return NotFound("Customer not found");
            }
        }
    }
}
