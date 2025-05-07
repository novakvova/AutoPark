using AutoMapper;
using WebAutoPark.Data.Entities;
using WebAutoPark.Models.Vehicle;

namespace WebAutoPark.Mapper;

public class VehicleMapper : Profile
{
    public VehicleMapper()
    {
        CreateMap<VehicleEntity, VehicleItemVM>()
            .ForMember(x=>x.StatusName, opt=>opt.MapFrom(x=>x.Status.Name))
            .ForMember(x=>x.CompanyName, opt=>opt.MapFrom(x=>x.Company.Name));
        CreateMap<VehicleCreateVM, VehicleEntity>();
        CreateMap<VehicleEditVM, VehicleEntity>()
            .ReverseMap();
    }
}
