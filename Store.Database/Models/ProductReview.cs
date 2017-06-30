using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Database.Models
{
    public class ProductReview
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        [StringLength(255)]
        public virtual string Title { get; set; }
        [StringLength(4096)]
        public virtual string Message { get; set; }
        public virtual Customer Author { get; set; }
        public virtual int Likes { get; set; }
        public virtual int Dislikes { get; set; }
        public virtual DateTime Date { get; set; }
    }
}
