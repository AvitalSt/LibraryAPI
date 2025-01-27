using Library.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=library_db");
        }
        /*public DataContext() {
            Books = new List<Book> { new Book { Id = 1, Name = "Dani", Author = "Miriam Levi", IsAvailable = true, BorrowedByUserId=null }};
            Users = new List<User> { new User { Id = 2, Name = "Avital", Phone = "0525660066", Email = "Avital@gmail.com" } };
        }*/
    }

}
