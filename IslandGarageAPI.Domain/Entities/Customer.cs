namespace IslandGarageAPI.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public required string CustomerNumber { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Address { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public required string Status { get; set; }
        public required DateTime DtAccess { get; set; }
    }
}
