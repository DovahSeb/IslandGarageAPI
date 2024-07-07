using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    public record VehicleResponse(int Id, string Make, string Model, string Year, string ChassisNo, int CustomerId);

}
