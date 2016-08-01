namespace BookLover.Web.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Http;

    using AutoMapper.QueryableExtensions;

    using DataAccessLayer.Data;
    using EntityModels;
    using Models.BindingModels.AuthorsBindingModels;
    using Models.DataTransferObjects;

    [RoutePrefix("api/Authors")]
    public class AuthorsController: BaseApiController
    {
        public AuthorsController(IBookLoverData data): base(data)
        {
        }

        //
        // GET: api/Authors
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAuthors()
        {
            var authors = this.Data.Authors.All()
                .Project()
                .To<AuthorDto>();

            return this.Ok(authors);
        }

        //
        // GET: api/Authors/{id:int}/Books
        [HttpGet]
        [Route("{id:int}/Books")]
        public IHttpActionResult GetBooksByAuthor(int id)
        {
            var author = this.Data.Authors
                .All()
                .Include(x => x.Books)
                .FirstOrDefault(x => x.Id == id);

            if (author == null)
            {
                return this.NotFound();
            }

            var books = author.Books.AsQueryable().Project().To<BookDto>();

            return this.Ok(books);
        }

        //
        // POST: api/Authors
        public IHttpActionResult CreateAuthor([FromBody]CreateAuthorBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newAuthor = new Author()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            this.Data.Authors.Add(newAuthor);
            this.Data.SaveChanges();

            return this.CreatedAtRoute(
                "",
                new
                {
                    Id = newAuthor.Id
                },
                newAuthor);
        }
    }
}