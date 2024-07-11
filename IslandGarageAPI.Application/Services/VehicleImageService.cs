using AutoMapper;
using IslandGarageAPI.Application.DTOs;
using IslandGarageAPI.Application.Interfaces;
using IslandGarageAPI.Domain.Entities;
using IslandGarageAPI.Domain.Interfaces.Repositories;
using IslandGarageAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace IslandGarageAPI.Application.Services
{
    public class VehicleImageService : IVehicleImageService
    {
        private readonly IVehicleImageRepository _vehicleImageRepository;
        private readonly IMapper _mapper;

        public VehicleImageService(IVehicleImageRepository vehicleImageRepository, IMapper mapper)
        {
            _vehicleImageRepository = vehicleImageRepository;
            _mapper = mapper;
        }

        public async Task<List<VehicleImageResponse>> GetAllVehicleImages()
        {
            var response = await _vehicleImageRepository.GetAllVehicleImages();

            return _mapper.Map<List<VehicleImageResponse>>(response);
        }

        public async Task<List<VehicleImageResponse>> AddVehicleImage(CreateVehicleImageRequest request)
        {
            using var memoryStream = new MemoryStream();
            await request.ImageFile.CopyToAsync(memoryStream);

            if(memoryStream.Length > 2097152)
            {
                return null;
            }

            var vehicleImage = new VehicleImage
            {
                FileName = request.FileName,
                ImageByte = memoryStream.ToArray(),
                Description = request.Description,
                Status = "I",
                DtAccess = DateTime.Now,
                CreatedAt = DateTime.Now,
            };

            var response = await _vehicleImageRepository.AddVehicleImage(vehicleImage);
            return _mapper.Map<List<VehicleImageResponse>>(response);
        }

        public Task<VehicleImageResponse> UpdateVehicleImage(UpdateVehicleImageRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleImageResponse> DeleteVehicleImage(int id)
        {
            throw new NotImplementedException();
        }
    }
}
