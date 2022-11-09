using Bookstore.Services.Core;
using Bookstore.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Bookstore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult AddBook(BookDto book)
        {
            try
            {
                return Ok(_booksService.AddBook(book));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetBooks()
        {
            return Ok(_booksService.GetBooks());
        }
    }
}
