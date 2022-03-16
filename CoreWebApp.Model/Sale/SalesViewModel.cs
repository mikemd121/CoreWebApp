using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CoreWebApp.Model.SalesViewModel
{
  public  class SalesViewModel : SalesModel
    {
        public IEnumerable<SelectListItem> customerList { get; set; }

        public IEnumerable<SelectListItem> propertyList { get; set; }
    }
}
