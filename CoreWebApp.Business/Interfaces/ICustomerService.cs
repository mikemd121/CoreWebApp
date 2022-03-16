using CoreWebApp.Core.Common;
using CoreWebApp.Data.EntityModels;
using CoreWebApp.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp.Business.Interfaces
{
   public interface ICustomerService
    {
        ResponseModel RegisterCustomer(CustomerModel customerModel);

        List<CustomerId> GetCustomerList();
    }
}
