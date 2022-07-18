using AutoMapper;
using DesafioKinvo.Domain.Entities;
using DesafioKinvo.WebApi.ViewModels;

namespace DesafioKinvo.WebApi.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Investment, InvestmentViewModel>().ReverseMap();
            CreateMap<Client, ClientViewModel>().ReverseMap();
        }
    }
}
