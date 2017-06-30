using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Database.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        [StringLength(255)]
        public virtual string Name { get; set; }
        [StringLength(8096)]
        public virtual string Ingredients { get; set; }
        [StringLength(8096)]
        public virtual string CategoryName { get; set; }
        public virtual double Price { get; set; }

        [StringLength(2046)]
        public virtual string ImageUrl { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual  ICollection<Cart> Carts { get; set; }
    }
}
