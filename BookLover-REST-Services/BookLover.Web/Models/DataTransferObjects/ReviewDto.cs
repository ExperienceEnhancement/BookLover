namespace BookLover.Web.Models.DataTransferObjects
{
    using Common.Mappings;
    using EntityModels;

    public class ReviewDto: IMapFrom<Review>
    {
        public string Comment { get; set; }

        public int Rate { get; set; }
    }
}