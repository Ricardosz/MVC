using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + ' ' + LastName;
            }
        }

        public virtual ICollection<Book> Books { get; set; }
    }
}