﻿using AutoMapper;
using IslandGarageAPI.Application.DTOs;
using IslandGarageAPI.Application.Interfaces;
using IslandGarageAPI.Domain.Entities;
using IslandGarageAPI.Domain.Interfaces.Repositories;

namespace IslandGarageAPI.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<VehicleResponse> GetById(int id)
        {
            var response = await _vehicleRepository.GetById(id);

            return _mapper.Map<VehicleResponse>(response);
        }

        public async Task<List<VehicleResponse>> GetVehicleByCustomerId(int customerId)
        {
            var response = await _vehicleRepository.GetByCustomerId(customerId);
            
            return _mapper.Map<List<VehicleResponse>>(response);
        }

        public async Task<List<VehicleResponse>> AddVehicle(CreateVehicleRequest request)
        {
            var vehicle = _mapper.Map<Vehicle>(request);
            var response = await _vehicleRepository.AddVehicle(vehicle);

            return _mapper.Map<List<VehicleResponse>>(response);
        }

        public async Task<VehicleResponse> UpdateVehicle(UpdateVehicleRequest request)
        {
            var vehicle = _mapper .Map<Vehicle>(request);
            var response = await _vehicleRepository.UpdateVehicle(vehicle);

            return _mapper.Map<VehicleResponse>(response);
        }

        public async Task<VehicleResponse> DeleteVehicle(int id)
        {
            var response = await _vehicleRepository.DeleteVehicle(id);

            return _mapper .Map<VehicleResponse>(response);
        }
    }
}
