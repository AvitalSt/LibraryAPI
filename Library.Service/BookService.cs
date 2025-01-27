using Library.Core.Models;
using Library.Core.Repositories;
using Library.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public BookService (IBookRepository bookRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public async Task<List<Book>> GetListAsync()
        {
            return await _bookRepository.GetAllAsync();
        }
        
        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<Book> AddAsync(Book book)
        {
            return await _bookRepository.AddAsync(book);
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            return await _bookRepository.UpdateAsync(book);
        }

        public async Task DeleteAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        public async Task<bool> BorrowBookAsync(int bookId, int userId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            if (book == null)
            {
                throw new Exception("Book not found.");
            }
            if (!book.IsAvailable)
            {
                throw new Exception("Book is not available for borrowing.");
            }
            var user = await _userRepository.GetByIdAsync(userId); 
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            return await _bookRepository.BorrowBookAsync(book, user);
        }

        public async Task<bool> ReturnBookAsync(int bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            if (book == null)
            {
                throw new Exception("Book not found.");
            }
            if (book.IsAvailable)
            {
                throw new Exception("Book is already available.");
            }
            return await _bookRepository.ReturnBookAsync(bookId);
        }
    }
}
