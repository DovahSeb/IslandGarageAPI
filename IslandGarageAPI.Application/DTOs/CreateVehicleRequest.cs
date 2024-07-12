using System.ComponentModel.DataAnnotations;

namespace IslandGarageAPI.Application.DTOs
{
    public class CreateVehicleRequest
    {
        [Required]
        public string Make { get; set; } = string.Empty;

        [Required]
        public string Model { get; set; } = string.Empty;

        [Required]
        public string Year { get; set; } = string.Empty;

        [Required]
        public string ChassisNo { get; set; } = string.Empty;

        [Required]
        public int CustomerId { get; set; }
    }

    public class UpdateVehicleRequest : CreateVehicleRequest
    {
        [Required]
        public int Id { get; set; }
    }

    public class VehicleResponse
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Make { get; set; } = string.Empty;

        [Required]
        public string Model { get; set; } = string.Empty;

        [Required]
        public string Year { get; set; } = string.Empty;

        [Required]
        public string ChassisNo { get; set;} = string.Empty;

        [Required]
        public int CustomerId { get; set; }

        public string? VehicleImage { get; set; }
    }

}
