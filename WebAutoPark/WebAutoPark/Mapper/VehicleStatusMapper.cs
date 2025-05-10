using AutoMapper;
using WebAutoPark.Data.Entities;
using WebAutoPark.Helpers;
using WebAutoPark.Models.VehicleStatus;

namespace WebAutoPark.Mapper;

public class VehicleStatusMapper : Profile
{
    public VehicleStatusMapper()
    {
        CreateMap<VehicleStatusEntity, VehicleStatusItemVM>();
        CreateMap<VehicleStatusCreateVM, VehicleStatusEntity>();
        CreateMap<VehicleStatusEditVM, VehicleStatusEntity>()
            .ReverseMap();

        CreateMap<VehicleStatusEntity, SelectItemViewModel>();
    }
}
