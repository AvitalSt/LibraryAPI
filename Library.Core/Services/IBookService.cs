using Library.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetListAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<Book> AddAsync(Book book);
        Task<Book> UpdateAsync(Book updateBook);
        Task DeleteAsync(int id);
        Task<bool> BorrowBookAsync(int bookId, int userId);
        Task<bool> ReturnBookAsync(int bookId);
    }
}
