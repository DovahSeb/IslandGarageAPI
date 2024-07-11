using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace IslandGarageAPI.Application.DTOs
{
    public class CreateVehicleImageRequest
    {
        [Required]
        public string FileName { get; set; } = string.Empty;

        [Required]
        public IFormFile ImageFile { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;
    }

    public class UpdateVehicleImageRequest
    {
        [Required]
        public int Id { get; set; }
    }

    public record VehicleImageResponse(int Id, byte[] ImageByte, string Description);
}
