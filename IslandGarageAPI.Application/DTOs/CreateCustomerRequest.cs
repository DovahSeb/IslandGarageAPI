using System.ComponentModel.DataAnnotations;

namespace IslandGarageAPI.Application.DTOs
{

    public class CreateCustomerRequest
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;
    }

    public class UpdateCustomerRequest : CreateCustomerRequest
    {
        [Required]
        public int Id { get; set; }
    }

    public record CustomerResponse(int id, string CustomerNumber, string FirstName, string LastName, string Address, string PhoneNumber, string Email);
}
