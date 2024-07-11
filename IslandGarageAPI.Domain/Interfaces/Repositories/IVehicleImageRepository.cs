using IslandGarageAPI.Domain.Entities;

namespace IslandGarageAPI.Domain.Interfaces.Repositories
{
    public interface IVehicleImageRepository
    {
        Task<List<VehicleImage>> GetAllVehicleImages();
        Task<List<VehicleImage>> AddVehicleImage(VehicleImage vehicleImage);
        Task<VehicleImage> UpdateVehicleImage(VehicleImage vehicleImage);
        Task<VehicleImage> DeleteVehicleImage(int id);
    }
}
