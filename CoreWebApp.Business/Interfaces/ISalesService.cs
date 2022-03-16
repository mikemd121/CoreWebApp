using CoreWebApp.Core.Common;
using CoreWebApp.Model.Property;
using CoreWebApp.Model.SalesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp.Business.Interfaces
{
    public interface ISalesService
    {
        ResponseModel SellProperty(SalesModel propertyModel);

        List<PropertyModel> GetSoldPropertyList();
    }
}
