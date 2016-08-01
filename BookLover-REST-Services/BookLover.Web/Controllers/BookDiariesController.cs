namespace BookLover.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using DataAccessLayer.Data;

    public class BookDiariesController: BaseApiController
    {
        public BookDiariesController(IBookLoverData data): base(data)
        {
        }

        // 
        // GET: api/BookDiaries/{id:int}
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetBookDiaries(int id)
        {
            var diaries = this.Data.BookDiaries
                .All()
                .Where(x => x.BookId == id)
               ;
        }
    }
}