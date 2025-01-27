using AutoMapper;
using Library.API.Models;
using Library.Core.DTOs;
using Library.Core.Models;
using Library.Core.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Libary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var books= await _bookService.GetListAsync();
            var ListDto = _mapper.Map<IEnumerable<BookDto>>(books);
            return Ok(ListDto);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var book= await _bookService.GetByIdAsync(id);
            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BookPostModel newBook)
        {
            var bookToAdd = new Book {  Name = newBook.Name, Author = newBook.Author ,IsAvailable=true}; ;
            var book = await _bookService.AddAsync(bookToAdd);
            return Ok(book);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BookPostModel updateBook)
        {
            var bookToUpdate = new Book {Id=id,Name=updateBook.Name, Author=updateBook.Author};
            var book = await _bookService.UpdateAsync(bookToUpdate);
            return Ok(book);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _bookService.DeleteAsync(id);
            return Ok();
        }

        // PUT api/<BooksController>/borrow
        [HttpPut("/borrow")]
        public async Task<ActionResult> BorrowBook([FromBody] BookBorrowModel bookBorrow) 
        {
            var result = await _bookService.BorrowBookAsync(bookBorrow.BookId, bookBorrow.UserId);
            if (!result)
                return BadRequest("Cannot borrow the book. Either the book or user does not exist, or the book is unavailable.");

            return Ok("Book borrowed successfully.");
        }

        // PUT api/<BooksController>/return
        [HttpPut("/return")]
        public async Task<ActionResult> ReturnBook(BookReturnModel returnBook)
        {
            var result = await _bookService.ReturnBookAsync(returnBook.BookId);
            if (!result)
                return BadRequest("Cannot return the book. Either the book does not exist or it is already available.");

            return Ok("Book returned successfully.");
        }
    }
}
