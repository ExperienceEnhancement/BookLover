namespace BookLover.Tests.IntegrationTests
{
    using System.Net.Http;
    using DataAccessLayer.Contexts;

    using EntityFramework.Extensions;

    using Microsoft.Owin.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Web;

    [TestClass]
    public static class TestingEngine
    {
        public static HttpClient HttpClient { get; private set; }

        private static TestServer TestWebServer { get; set; }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext testContext)
        {
            TestWebServer = TestServer.Create<Startup>();

            HttpClient = TestWebServer.HttpClient;
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            TestWebServer.Dispose();
        }

        public static void CleanDatabase()
        {
            using (var dbContext = new BookLoverDbContext())
            {
                dbContext.Authors.Delete();
                dbContext.DiaryAccesses.Delete();
                dbContext.BookDiaries.Delete();
                dbContext.DiaryNotes.Delete();
                dbContext.Reviews.Delete();
                dbContext.Users.Delete();
                dbContext.SaveChanges();
            }
        }

        public static void AddSampleData<T>(T newEntityData) where T : class
        {
            var dbContext = new BookLoverDbContext();
            using (dbContext)
            {
                dbContext.Set<T>().Add(newEntityData);
                dbContext.SaveChanges();
            }
        }
    }
}
