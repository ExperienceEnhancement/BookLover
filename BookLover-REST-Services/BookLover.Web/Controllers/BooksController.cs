namespace BookLover.Web.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Http;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using DataAccessLayer.Data;
    using EntityModels;

    using Microsoft.Ajax.Utilities;
    using Models.BindingModels;
    using Models.BindingModels.BooksBindingModels;
    using Models.DataTransferObjects;

    [RoutePrefix("api/books")]
    public class BooksController: BaseApiController
    {
        public BooksController(IBookLoverData data): base(data)
        {
        }

        //
        // GET: api/books
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllBooks([FromUri]BooksSearchBindingModel model)
        {
            var booksQuery = this.Data.Books
                .All()
                .Include(x => x.Author)
                .Project().To<BookDto>();

            if (model != null && !model.Title.IsNullOrWhiteSpace())
            {
                booksQuery = booksQuery.Where(x => x.Title.Contains(model.Title));
            }

            if (model != null && !model.Summary.IsNullOrWhiteSpace())
            {
                booksQuery = booksQuery.Where(x => x.Summary.Contains(model.Summary));
            }

            var booksResult = booksQuery.ToList();

            return this.Ok(booksResult);
        }

        //
        // GET: api/books/{id:int}
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetBook(int id)
        {
            var book = this.Data.Books.Find(id);

            if (book == null)
            {
                return this.NotFound();
            }

            var bookDto = Mapper.Map<Book, BookDto>(book);

            return this.Ok(bookDto);
        }

        //
        // POST: api/books
        [HttpPost]
        [Route("", Name = "CreateBook")]
        public IHttpActionResult CreateBook([FromBody]CreateEditBookBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (!this.Data.Authors.All().Any(x => x.Id == model.AuthorId))
            {
                this.ModelState.AddModelError("AuthorId", new InvalidOperationException("The author does not exist in the database"));
                return this.BadRequest(this.ModelState);
            }

            var newBook = new Book()
            {
                Title = model.Title,
                Summary = model.Summary,
                AuthorId = model.AuthorId
            };

            this.Data.Books.Add(newBook);
            this.Data.SaveChanges();

            return this.CreatedAtRoute(
                "CreateBook",
                new
                {
                    Id = newBook.Id
                },
                newBook);
        }


        //
        // PATCH: api/books/{id:int}
        [HttpPatch] 
        [Route("{id:int}")]
        public IHttpActionResult EditBook(int id, [FromBody]CreateEditBookBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var book = this.Data.Books.Find(id);

            if (book == null)
            {
                return this.NotFound();
            }

            if (!this.Data.Authors.All().Any(x => x.Id == model.AuthorId))
            {
                this.ModelState.AddModelError("AuthorId", new InvalidOperationException("The author does not exist in the database"));
                return this.BadRequest(this.ModelState);
            }

            book.Title = model.Title;

            book.Summary = model.Summary;

            book.AuthorId = model.AuthorId;

            this.Data.Books.Update(book);
            this.Data.SaveChanges();

            var bookDto = Mapper.Map<Book, BookDto>(book);

            return this.Ok(bookDto);
        }
    }
}