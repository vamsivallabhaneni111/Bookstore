using AutoMapper;
using Bookstore.Domain;
using Bookstore.Services.Models;

namespace Bookstore.Services.Mappers
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
