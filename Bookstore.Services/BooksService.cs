using AutoMapper;
using Bookstore.Domain;
using Bookstore.Repository.Entities;
using Bookstore.Services.Core;
using Bookstore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Services
{
    public class BooksService : IBooksService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public BooksService(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public BookDto AddBook(BookDto book)
        {
            book.Id = Guid.NewGuid();
            var bookEntity = _mapper.Map<BookDto, Book>(book);
            _bookRepository.Add(bookEntity);
            return book;
        }

        public BookDto GetBookById(Guid id)
        {
            throw new NotImplementedException();
        }

        public BookDto GetBookByName(string name)
        {
            throw new NotImplementedException();
        }

        public IList<BookDto> GetBooks()
        {
            var books = _bookRepository.Find(_ => true).ToList();
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDto>>(books).ToList<BookDto>();
        }
    }
}
