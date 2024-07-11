using IslandGarageAPI.Application.DTOs;
using IslandGarageAPI.Application.Interfaces;
using IslandGarageAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IslandGarageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VehicleImageController : ControllerBase
    {
        private readonly IVehicleImageService _vehicleImageService;

        public VehicleImageController(IVehicleImageService vehicleImageService)
        {
            _vehicleImageService = vehicleImageService;
        }

        [HttpGet]
        [Route("GetAllVehicleImages")]
        public async Task<ActionResult<List<VehicleImageResponse>>> GetAllVehicleImages()
        {
            var vehicleImages = await _vehicleImageService.GetAllVehicleImages();

            return Ok(vehicleImages);
        }

        [HttpPost]
        [Route("AddVehicleImage")]
        public async Task<ActionResult<List<VehicleImageResponse>>> AddVehicleImage([FromForm] CreateVehicleImageRequest request)
        {
            var newVehicleImage = await _vehicleImageService.AddVehicleImage(request);

            return Ok(newVehicleImage);
        }
    }
}
