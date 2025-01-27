using Library.Core.Models;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.Include(b => b.User).ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.Include(b => b.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Book> AddAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateAsync(Book updateBook)
        {
            var book = await GetByIdAsync(updateBook.Id);
            if (book is null)
            {
                throw new Exception("Book not found");
            }
            book.Name = updateBook.Name;
            book.Author = updateBook.Author;
            book.IsAvailable= updateBook.IsAvailable;
            book.User = updateBook.User;
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task DeleteAsync(int id)
        {
            var book = await GetByIdAsync(id);
            if (book is null)
            {
                throw new Exception("Book not found");
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> BorrowBookAsync(Book book, User user)
        {
            book.IsAvailable = false;
            book.User = user; 
            await _context.SaveChangesAsync(); 
            return true;
        }

        public async Task<bool> ReturnBookAsync(int bookId)
        {
            var book = await GetByIdAsync(bookId);
            book.IsAvailable = true;
            book.User = null; 
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
