using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Book name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        public string Author { get; set; }

        public bool IsAvailable { get; set; }

        public User? User { get; set; }
    }
}
