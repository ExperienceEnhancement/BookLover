namespace BookLover.Web.Controllers
{
    using System.Web.Http;

    using AutoMapper.QueryableExtensions;

    using DataAccessLayer.Contexts;
    using DataAccessLayer.Data;
    using Models.DataTransferObjects;

    [RoutePrefix("api/Authors")]
    public class AuthorsController: BaseApiController
    {
        public AuthorsController(IBookLoverData data): base(data)
        {
        }

        //
        // GET: api/authors
        [Route("")]
        public IHttpActionResult GetAuthors()
        {
            var context = new BookLoverDbContext();

            var authors = this.Data.Authors.All()
                .Project()
                .To<AuthorDto>();

            return this.Ok(authors);
        }
    }
}