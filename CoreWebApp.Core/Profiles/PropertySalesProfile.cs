using AutoMapper;
using CoreWebApp.Data.EntityModels;
using CoreWebApp.Model.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp.Core.Profiles
{
    public class PropertySalesProfile : Profile
    {
        public PropertySalesProfile()
        {
            CreateMap<Sale, PropertyModel>().ForMember(dest => dest.CreatedDateTime, opt => opt.MapFrom(src => src.CreatedDateTime))
                .ForMember(dest => dest.PropertyName, opt => opt.MapFrom(src => src.Property.PropertyName))
                .ForMember(dest => dest.PropertyNo, opt => opt.MapFrom(src => src.Property.PropertyNo))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Property.Street))
                 .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Property.City))
                .ForMember(dest => dest.PropertyType, opt => opt.MapFrom(src => src.Property.PropertyType))
                 .ForMember(dest => dest.BuyerName, opt => opt.MapFrom(src => src.Customer.Name))
                  .ForMember(dest => dest.BuyerAddress, opt => opt.MapFrom(src => src.Customer.Address));
        }
    }
}
