using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp.Data.EntityModels
{
    public class Property : BaseEntity
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? PropertyId { get; set; }
        public string PropertyName { get; set; }

        public string PropertyNo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public string PropertyType { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

    }
}
