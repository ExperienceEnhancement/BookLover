namespace BookLover.Web.Controllers
{
    using System.Web.Http;
    using DataAccessLayer.Data;

    public class BaseApiController: ApiController
    {
        public BaseApiController(IBookLoverData data)
        {
            this.Data = data;
        }

        protected IBookLoverData Data { get; private set; }
    }
}