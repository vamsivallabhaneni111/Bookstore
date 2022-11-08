using System;

namespace Bookstore.Services.Models
{
    public class BookDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Genere { get; set; }
    }
}
