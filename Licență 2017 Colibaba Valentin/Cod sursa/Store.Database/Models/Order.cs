using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Database.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual DateTime Date { get; set; }
    }
}
