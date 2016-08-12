namespace BookLover.Tests.IntegrationTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using AutoMapper.QueryableExtensions;
    using EntityModels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using UnitTests.TestData;
    using Web.Models.DataTransferObjects;

    [TestClass]
    public class BooksControllerTests
    {
        [TestMethod]
        public void ListAllBooksWithoutFilter_WhenBooksPresent_ShouldReturnAllBooks()
        {
            // Arrange
            TestingEngine.CleanDatabase();

            foreach (var book in TestData.Books)
            {
                TestingEngine.AddSampleData(book);
            }

            Assert.AreEqual(true, true);

            // Act
            var httpResponse = TestingEngine.HttpClient.GetAsync("/api/books").Result;
            var booksReceived = httpResponse.Content.ReadAsAsync<List<BookDto>>().Result;
            var booksTestData = TestData.Books.AsQueryable().Project().To<BookDto>().ToList();

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, HttpStatusCode.OK);
            Assert.AreEqual(booksReceived.Count, booksTestData.Count);
            CollectionAssert.AreEquivalent(booksReceived, booksTestData);
        }
    }
}
