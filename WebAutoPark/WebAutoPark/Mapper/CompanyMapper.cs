using AutoMapper;
using WebAutoPark.Data.Entities;
using WebAutoPark.Helpers;
using WebAutoPark.Models.Company;

namespace WebAutoPark.Mapper;

public class CompanyMapper : Profile
{
    public CompanyMapper()
    {
        CreateMap<CompanyEntity, CompanyItemVM>();
        CreateMap<CompanyCreateVM, CompanyEntity>();
        CreateMap<CompanyEditVM, CompanyEntity>()
            .ReverseMap();

        CreateMap<CompanyEntity, SelectItemViewModel>();
    }
}
