using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp.Model.Customer
{
    public class CustomerModel
    {
        [Required(ErrorMessage = "Name is required")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public String Address { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public String Email { get; set; }


    }
}
