using Bookstore.Controllers;
using Bookstore.Services.Core;
using Bookstore.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Xunit;

namespace Bookstore.Api.IntegrationTests.Steps.BooksControllerFeature
{
    [Binding]
    public class BooksControllerSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly BooksController _booksController;

        public BooksControllerSteps(ScenarioContext scenarioContext, BooksController booksController)
        {
            _scenarioContext = scenarioContext;
            _booksController = booksController;
        }

        [Given(@"I have a book with name '(.*)' having cost of '(.*)' with genere '(.*)'")]
        public void GivenIHaveABookWithNameHavingCostOfWithGenere(string name, double price, string genere)
        {
            // Implement the step logic
            var book = new BookDto
            {
                Name = name,
                Price = price,
                Genere = genere
            };

            // Call the appropriate action on the BooksController
            var booksResult = _booksController.AddBook(book);

            if (booksResult is OkObjectResult okObjectResult)
            {
                var books = okObjectResult.Value as BookDto;

                // Store the retrieved books in the ScenarioContext
                _scenarioContext.Set<BookDto>(books, "AddBook");
            }
        }

        [Then("I verified book is added with name '(.*)' having cost of '(.*)' with genere '(.*)'")]
        public void ThenIVerifiedBookIsAddedWithNameHavingCostOfWithGenere(string expectedName, double expectedPrice, string expectedGenere)

        {
            var book = _scenarioContext.Get<BookDto>("AddBook");

            Assert.Equal(expectedName, book.Name);
            Assert.Equal(expectedPrice, book.Price);
            Assert.Equal(expectedGenere, book.Genere);
        }

        [When("I request all books")]
        public void WhenIRequestAllBooks()
        {
            // Implement the step logic
            var booksResult = _booksController.GetBooks();

            if (booksResult is OkObjectResult okObjectResult)
            {
                var books = okObjectResult.Value as List<BookDto>;

                // Store the retrieved books in the ScenarioContext
                _scenarioContext.Set<List<BookDto>>(books, "Books");
            }
        }

        [Then("I should have (.*) books")]
        public void ThenIShouldHaveNumberOfBooks(int expectedCount)
        {
            var books = _scenarioContext.Get<List<BookDto>>("Books");

            Assert.NotNull(books);
            Assert.Equal(expectedCount, books.Count);
        }
    }
}
