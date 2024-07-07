using IslandGarageAPI.Application.DTOs;
using IslandGarageAPI.Domain.Entities;

namespace IslandGarageAPI.Application.Interfaces
{
    public interface IVehicleService
    {
        Task<VehicleResponse> GetById(int id);
        Task<List<VehicleResponse>> GetVehicleByCustomerId(int customerId);
        Task<List<VehicleResponse>> AddVehicle(CreateVehicleRequest request);
        Task<VehicleResponse> UpdateVehicle(UpdateVehicleRequest request);
        Task<VehicleResponse> DeleteVehicle(int id);
    }
}
