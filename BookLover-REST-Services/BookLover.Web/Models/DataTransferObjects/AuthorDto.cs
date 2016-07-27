namespace BookLover.Web.Models.DataTransferObjects
{
    using Common.Mappings;
    using EntityModels;

    public class AuthorDto: IMapFrom<Author>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}