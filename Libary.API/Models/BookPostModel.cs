using System.ComponentModel.DataAnnotations;

namespace Library.API.Models
{
    public class BookPostModel
    {
        [Required(ErrorMessage = "Book name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        public string Author { get; set; }
    }
}
