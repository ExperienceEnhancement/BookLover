namespace BookLover.Web.Controllers
{
    using DataAccessLayer.Data;

    public class BooksController: BaseApiController
    {
        public BooksController(IBookLoverData data): base(data)
        {
        }
    }
}