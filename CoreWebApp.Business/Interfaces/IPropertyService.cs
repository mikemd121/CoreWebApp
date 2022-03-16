using CoreWebApp.Core.Common;
using CoreWebApp.Data.EntityModels;
using CoreWebApp.Model.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp.Business.Interfaces
{
   public interface IPropertyService
    {
        ResponseModel RegisterProperty(PropertyModel propertyModel);

        List<Property> GetAvailablePropertyByCustomerId(int customerId);
    }
}
