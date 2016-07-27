namespace BookLover.Web.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using DataAccessLayer.Contexts;
    using Models.DataTransferObjects;

    [RoutePrefix("api/Authors")]
    public class AuthorsController: ApiController
    {
        //
        // GET: api/authors
        [Route("")]
        public IHttpActionResult GetAuthors()
        {
            var context = new BookLoverDbContext();

            var authors = context.Authors
                .Project()
                .To<AuthorDto>();

            return this.Ok(authors);
        }
    }
}