using AutoMapper;
using IslandGarageAPI.Application.DTOs;
using IslandGarageAPI.Domain.Entities;

namespace IslandGarageAPI.Application.Mapper
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<CreateVehicleRequest, Vehicle>();
            CreateMap<UpdateVehicleRequest, Vehicle>();
            CreateMap<Vehicle, VehicleResponse>()
                .ForMember(dest => dest.VehicleImage, opt => opt.MapFrom(src => src.VehicleImage != null ? Convert.ToBase64String(src.VehicleImage.ImageByte) : null));
        }
    }
}
