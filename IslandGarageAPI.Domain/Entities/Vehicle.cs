namespace IslandGarageAPI.Domain.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public required string Make { get; set; }
        public required string Model { get; set; }
        public required string Year { get; set; }
        public required string ChassisNo { get; set; }
        public required int CustomerId { get; set; }
        public required string Status { get; set; }
        public required DateTime DtAccess { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
