using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp.Model.SalesViewModel
{
  public  class SalesModel
    {
        [Display(Name = "Property")]
        public int PropertyId { get; set; }

        [Display(Name = "Buyer")]
        public int CustomerId { get; set; }
    }
}
