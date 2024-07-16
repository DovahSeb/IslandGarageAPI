namespace IslandGarageAPI.Application.DTOs
{
    public record CreateVehicleRequest(string Make, string Model, string Year, string ChassisNo, int CustomerId, int? VehicleImageId);

    public record UpdateVehicleRequest(int Id, string Make, string Model, string Year, string ChassisNo, int CustomerId, int? VehicleImageId) : CreateVehicleRequest(Make, Model, Year, ChassisNo, CustomerId, VehicleImageId);

    public record VehicleResponse(int Id, string Make, string Model, string Year, string ChassisNo, int CustomerId, string? VehicleImage);

}
