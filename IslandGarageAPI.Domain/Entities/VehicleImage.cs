namespace IslandGarageAPI.Domain.Entities
{
    public class VehicleImage
    {
        public int Id { get; set; }
        public required string FileName { get; set; }
        public required byte[] ImageByte { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; }
        public required DateTime DtAccess { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
