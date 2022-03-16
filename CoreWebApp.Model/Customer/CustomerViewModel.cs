using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CoreWebApp.Model.Customer
{
   public class CustomerViewModel : CustomerModel
    {
        /// <summary>
        /// Gets or sets the website ids.
        /// </summary> 
        public IEnumerable<SelectListItem> customerList { get; set; }
    }
}
