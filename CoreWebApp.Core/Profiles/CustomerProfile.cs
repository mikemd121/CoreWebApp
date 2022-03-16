using AutoMapper;
using CoreWebApp.Data.EntityModels;
using CoreWebApp.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp.Core.Profiles
{
   public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerModel, Customer>().ForMember(dest => dest.CreatedDateTime, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
