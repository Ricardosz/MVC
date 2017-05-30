using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models
{
    public class Cart
    {
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [StringLength(255)]
        public string SessionId { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}