using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreWebApp.Data.EntityModels
{
    public class Customer : BaseEntity
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? CustomerId { get; set; }
        public String Name { get; set; }

        public String Address { get; set; }

        public String Email { get; set; }
    }
}
