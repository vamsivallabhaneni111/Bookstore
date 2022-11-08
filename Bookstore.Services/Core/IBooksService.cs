using Bookstore.Services.Models;
using System;
using System.Collections.Generic;

namespace Bookstore.Services.Core
{
    public interface IBooksService
    {
        public IList<BookDto> GetBooks();
        public BookDto GetBookById(Guid id);
        public BookDto GetBookByName(string name);
        public BookDto AddBook(BookDto book);
    }
}
