using IslandGarageAPI.Domain.Entities;

namespace IslandGarageAPI.Domain.Interfaces.Repositories
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetById(int id);
        Task<List<Vehicle>> GetByCustomerId(int customerId);
        Task<List<Vehicle>> AddVehicle(Vehicle vehicle);
        Task<Vehicle> UpdateVehicle(Vehicle vehicle);
        Task<Vehicle> DeleteVehicle(int id);
    }
}
