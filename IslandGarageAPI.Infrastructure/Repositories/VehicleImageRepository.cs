using IslandGarageAPI.Domain.Entities;
using IslandGarageAPI.Domain.Interfaces.Repositories;
using IslandGarageAPI.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace IslandGarageAPI.Infrastructure.Repositories
{
    public sealed class VehicleImageRepository : IVehicleImageRepository
    {
        private readonly DatabaseContext _context;

        public VehicleImageRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<VehicleImage>> GetAllVehicleImages()
        {
            var vehicleImages = await _context.VehicleImages
                .Where(x => x.Status != "D")
                .OrderBy(x => x.Description)
                .ToListAsync();

            return vehicleImages;
        }

        public async Task<List<VehicleImage>> AddVehicleImage(VehicleImage vehicleImage)
        {
            _context.VehicleImages.Add(vehicleImage);
            await _context.SaveChangesAsync();

            return await GetAllVehicleImages();
        }

        public Task<VehicleImage> UpdateVehicleImage(VehicleImage vehicleImage)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleImage> DeleteVehicleImage(int id)
        {
            throw new NotImplementedException();
        }

    }
}
