using Library.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);     
        Task<Book> AddAsync(Book book);
        Task<Book> UpdateAsync(Book updateBook);
        Task DeleteAsync(int id);
        Task<bool> BorrowBookAsync(Book book, User user);
        Task<bool> ReturnBookAsync(int bookId);
    }
}

