using AutoMapper;
using IslandGarageAPI.Application.DTOs;
using IslandGarageAPI.Domain.Entities;

namespace IslandGarageAPI.Application.Mapper
{
    public class VehicleImageProfile : Profile
    {
        public VehicleImageProfile()
        {
            CreateMap<CreateVehicleImageRequest, VehicleImage>();
            CreateMap<UpdateVehicleImageRequest, VehicleImage>();
            CreateMap<VehicleImage, VehicleImageResponse>();
        }
    }
}
