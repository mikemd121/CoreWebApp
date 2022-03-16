using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp.Model.Property
{
  public  class PropertyModel
    {
        public string PropertyName { get; set; }
        public string PropertyNo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public string PropertyType { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
  
        public String BuyerName { get; set; }

        public String BuyerAddress { get; set; }

        public DateTime? CreatedDateTime { get; set; }

    }
}
