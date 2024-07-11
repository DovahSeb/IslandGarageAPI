using IslandGarageAPI.Application.DTOs;

namespace IslandGarageAPI.Application.Interfaces
{
    public interface IVehicleImageService
    {
        Task<List<VehicleImageResponse>> GetAllVehicleImages();
        Task<List<VehicleImageResponse>> AddVehicleImage(CreateVehicleImageRequest request);
        Task<VehicleImageResponse> UpdateVehicleImage(UpdateVehicleImageRequest request);
        Task<VehicleImageResponse> DeleteVehicleImage(int id);
    }
}
