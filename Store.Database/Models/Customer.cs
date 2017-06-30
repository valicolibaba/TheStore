using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Database.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        [StringLength(255)]
        public virtual string FirstName { get; set; }
        [StringLength(255)]
        public virtual string LastName { get; set; }
        [StringLength(255)]
        [Index("EmailIndex",IsUnique = true)]
        public virtual string Email { get; set; }
        [StringLength(255)]
        public virtual string Address { get; set; }
        [StringLength(100)]
        public virtual string Phone { get; set; }
        [StringLength(64)]
        public virtual string Password { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
    }
}
