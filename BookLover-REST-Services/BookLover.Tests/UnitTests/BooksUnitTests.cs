namespace BookLover.Tests.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using System.Web.Http.Routing;

    using AutoMapper.QueryableExtensions;
    using EntityModels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Mocks;
    using Web.Controllers;
    using Web.Models.DataTransferObjects;

    [TestClass]
    public class BooksUnitTests
    {
        [TestMethod]
        public void GetAllBooks_WhenBooksAvailable_ShouldReturnAllBooks()
        {
            // Arrange
            var booksLoverData = new BookLoverDataMock();
            foreach (var author in TestData.TestData.Authors)
            {
                booksLoverData.Authors.Add(author);
            }

            foreach (var book in TestData.TestData.Books)
            {
                booksLoverData.Books.Add(book);
            }

            AutoMapper.Mapper.CreateMap<Book, BookDto>().ForMember(
                dest => dest.Author,
                options => options.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName
            ));

            // Act
            var booksController = new BooksController(booksLoverData);
            this.SetupControllerForTesting(booksController, "books");
            var httpResponse =
                booksController.GetAllBooks(null)
                .ExecuteAsync(new CancellationToken()).Result;
            var booksReceived = httpResponse.Content.ReadAsAsync<List<BookDto>>().Result;
            var booksList = booksLoverData.Books.All().Project().To<BookDto>().ToList();
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.AreEqual(booksLoverData.Books.All().Count(), booksReceived.Count);
            CollectionAssert.AreEquivalent(booksList, booksReceived);
        }


        [TestMethod]
        public void GetAllBooks_WhenNoBooksPresent_ShouldReturnEmptyArray()
        {
            // Arange
            var booksLoverData = new BookLoverDataMock();

            // Act
            var booksController = new BooksController(booksLoverData);
            this.SetupControllerForTesting(booksController, "books");
            var httpResponse =
                booksController.GetAllBooks(null)
                .ExecuteAsync(new CancellationToken()).Result;
            var booksReceived = httpResponse.Content.ReadAsAsync<List<BookDto>>().Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.AreEqual(0, booksReceived.Count);
        }

        [TestMethod]
        public void GetBook_WhenPresent_ShouldReturnTheBook()
        {
            // Arrange
            var booksLoverData = new BookLoverDataMock();
            booksLoverData.Books.Add(TestData.TestData.Books.First());

            // Act
            var booksController = new BooksController(booksLoverData);
            this.SetupControllerForTesting(booksController, "books");
            var httpResponse =
                booksController.GetBook(1)
                .ExecuteAsync(new CancellationToken()).Result;
            var bookReceived = httpResponse.Content.ReadAsAsync<BookDto>().Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.AreEqual(bookReceived.Id, TestData.TestData.Books.First().Id);
            Assert.AreEqual(bookReceived.Title, TestData.TestData.Books.First().Title);
            Assert.AreEqual(bookReceived.Summary, TestData.TestData.Books.First().Summary);
            Assert.AreEqual(bookReceived.Author, $"{TestData.TestData.Books.First().Author.FirstName} {TestData.TestData.Books.First().Author.LastName}");
        }

        [TestMethod]
        public void GetBook_WhenNotPresent_ShouldReturnNotFound()
        {
            // Arrange
            var booksLoverData = new BookLoverDataMock();

            // Act
            var booksController = new BooksController(booksLoverData);
            this.SetupControllerForTesting(booksController, "books");
            var httpResponse =
                booksController.GetBook(-1)
                .ExecuteAsync(new CancellationToken()).Result;
            
            // Arrange
            Assert.AreEqual(HttpStatusCode.NotFound, httpResponse.StatusCode);
        }

        private void SetupControllerForTesting(ApiController controller, string controllerName)
        {
            string serverUrl = "http://sample-url.com";

            // Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            // Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            // Apply the routes to the controller
            controller.RequestContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary
                {
                    { "controller", controllerName }
                });
        }
    }
}
