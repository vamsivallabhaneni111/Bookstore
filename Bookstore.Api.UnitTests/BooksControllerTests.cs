using Bookstore.Controllers;
using Bookstore.Services.Core;
using Bookstore.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Bookstore.Api.UnitTests
{
    public class BooksControllerTests
    {
        private readonly BooksController booksController;
        private readonly Mock<IBooksService> bookServiceMock;

        public BooksControllerTests()
        {
            bookServiceMock = new Mock<IBooksService>();
            booksController = new BooksController(bookServiceMock.Object);
        }

        [Fact]
        public void Test1()
        {
            // Arrange
            var expectedBooks = new List<BookDto> 
            {
                new BookDto
                {
                    Id = Guid.NewGuid(),
                    Name = "Batman",
                    Price = 1000,
                    Genere = "Comics",
                }
            };
            bookServiceMock.Setup(service => service.GetBooks()).Returns(expectedBooks);

            // Act
            var result = booksController.GetBooks();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var books = Assert.IsType<List<BookDto>>(okResult.Value);
            Assert.Equal(expectedBooks.Count, books.Count);
            Assert.Equal(expectedBooks[0].Name, books[0].Name);
            Assert.Equal(expectedBooks[0].Price, books[0].Price);
            Assert.Equal(expectedBooks[0].Genere, books[0].Genere);
        }
    }
}
