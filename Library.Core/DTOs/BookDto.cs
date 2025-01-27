using Library.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public bool IsAvailable { get; set; }

        public UserDto? User { get; set; }
    }
}