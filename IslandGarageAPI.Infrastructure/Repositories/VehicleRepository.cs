using IslandGarageAPI.Domain.Entities;
using IslandGarageAPI.Domain.Interfaces.Repositories;
using IslandGarageAPI.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace IslandGarageAPI.Infrastructure.Repositories
{
    public sealed class VehicleRepository : IVehicleRepository
    {
        private readonly DatabaseContext _context;

        public VehicleRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Vehicle>> GetByCustomerId(int customerId)
         {
            var customerVehicles = await _context.Vehicles
                .Where(x => x.CustomerId == customerId && x.Status != "D")
                .Include(x => x.VehicleImage)
                .ToListAsync();

            return customerVehicles;
        }


        public async Task<List<Vehicle>> AddVehicle(Vehicle vehicle)
        {
            vehicle.Status = "I";
            vehicle.DtAccess = DateTime.Now;
            vehicle.CreatedAt = DateTime.Now;

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            return await GetByCustomerId(vehicle.CustomerId);
        }

        public Task<Vehicle> DeleteVehicle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle> UpdateVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
