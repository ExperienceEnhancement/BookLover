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
    using Models.BindingModels.ReviewsBindingModels;
    using Models.DataTransferObjects;

    using Microsoft.AspNet.Identity;

    [RoutePrefix("api/Reviews")]
    public class ReviewsController: BaseApiController
    {
        public ReviewsController(IBookLoverData data) : base(data)
        {
        }

        //
        // GET: api/Reviews/{username}/{bookId}
        [HttpGet]
        [Route("details/{username}/{bookId:int}", Name = "GetReview")]
        public IHttpActionResult GetReview(string username, int bookId)
        {
            var review = this.Data.Reviews
                .All()
                .Include(x => x.User)
                .FirstOrDefault(x => x.User.UserName == username && x.BookId == bookId);

            if (review == null)
            {
                return this.NotFound();
            }

            var result = Mapper.Map<Review, ReviewDto>(review);

            return this.Ok(result);
        }

        //
        // GET: api/Reviews/Book/{id:int}
        [HttpGet]
        [Route("Book/{id:int}")]
        public IHttpActionResult GetReviewsByBook(int id)
        {
            var reviews = this.Data.Reviews
                .All()
                .Where(x => x.BookId == id)
                .Project()
                .To<ReviewDto>();


            return this.Ok(reviews);
        }

        //
        // GET: api/Reviews/User/{username}
        [HttpGet]
        [Route("User/{username}")]
        public IHttpActionResult GetReviewsByUser(string username)
        {
            var reviews = this.Data.Reviews
                .All()
                .Where(x => x.User.UserName == username)
                .Project()
                .To<ReviewDto>();

            return this.Ok(reviews);
        }

        //
        // POST: api/Reviews
        [HttpPost]
        [Route("")]
        [Authorize]
        public IHttpActionResult CreateReview([FromBody]CreateReviewBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (!this.Data.Books.All().Any(x => x.Id == model.BookId))
            {
                this.ModelState.AddModelError("BookId", new InvalidOperationException("The book does not exist in the database"));
            }

            var userId = this.User.Identity.GetUserId();

            var newReview = new Review()
            {
                Comment = model.Comment,
                Rate = model.Rate,
                BookId = model.BookId,
                UserId = userId
            };

            this.Data.Reviews.Add(newReview);

            return this.CreatedAtRoute(
                "GetReview",
                new
                {
                    Username = newReview.User.UserName,
                    BookId = newReview.BookId
                },
                newReview);
        }
    }
}