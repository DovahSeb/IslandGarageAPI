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

        public async Task<Vehicle?> GetById(int id)
        {
            var vehicle = await _context.Vehicles
                .Where(x => x.Id.Equals(id))
                .Include(x => x.VehicleImage)
                .FirstOrDefaultAsync();

            return vehicle;
        }

        public async Task<List<Vehicle>> GetByCustomerId(int customerId)
        {
            var customerVehicles = await _context.Vehicles
                .Where(x => x.CustomerId == customerId && x.Status != "D")
                .Include(x => x.VehicleImage)
                .OrderByDescending(x => x.Id)
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

        public async Task<Vehicle> UpdateVehicle(Vehicle vehicle)
        {
            var existingVehicle = await _context.Vehicles.FindAsync(vehicle.Id);

            if (existingVehicle is not null)
            {
                existingVehicle.Make = vehicle.Make;
                existingVehicle.Model = vehicle.Model;
                existingVehicle.Year = vehicle.Year;
                existingVehicle.ChassisNo = vehicle.ChassisNo;
                existingVehicle.VehicleImageId = vehicle.VehicleImageId;
                existingVehicle.Status = "M";
                existingVehicle.DtAccess = DateTime.Now;

                _context.Vehicles.Update(existingVehicle);
                await _context.SaveChangesAsync();

                return await GetById(existingVehicle.Id);
            }

            return null;
        }

        public Task<Vehicle> DeleteVehicle(int id)
        {
            throw new NotImplementedException();
        }
    }
}
