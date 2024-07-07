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
        [Route("GetVehicleByCustomerId/{customerId}")]
        public async Task<ActionResult<List<VehicleResponse>>> GetVehicleByCustomerId(int customerId)
        {
            var vehicle = await _vehicleService.GetVehicleByCustomerId(customerId);
            if (vehicle is null)
            {
                return NotFound("Vehicle not found");
            }

            return Ok(vehicle);
        }

        [HttpPost]
        [Route("AddVehicle")]
        public async Task<ActionResult<VehicleResponse>> AddCustomer(CreateVehicleRequest request)
        {
            var newVehicle = await _vehicleService.AddVehicle(request);
            return Ok(newVehicle);
        }
    }
}
