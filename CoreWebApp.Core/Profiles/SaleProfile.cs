using AutoMapper;
using CoreWebApp.Data.EntityModels;
using CoreWebApp.Model.SalesViewModel;
using System;

namespace CoreWebApp.Core.Profiles
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<SalesModel, Sale>().ForMember(dest => dest.CreatedDateTime, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
