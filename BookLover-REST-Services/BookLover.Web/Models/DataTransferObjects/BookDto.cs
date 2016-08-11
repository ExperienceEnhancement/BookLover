namespace BookLover.Web.Models.DataTransferObjects
{
    using AutoMapper;
    using Common.Mappings;
    using EntityModels;

    public class BookDto : IMapFrom<Book>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public int AuthorId { get; set; }

        public string Author { get; set; }

        public override bool Equals(object obj)
        {
            var comparedObject = obj as BookDto;

            if (comparedObject == null)
            {
                return false;
            }

            var areEqual = this.Id.Equals(comparedObject.Id) &&
                this.Title.Equals(comparedObject.Title) &&
                this.Summary.Equals(comparedObject.Summary) &&
                this.AuthorId.Equals(comparedObject.AuthorId) &&
                this.Author.Equals(comparedObject.Author);

            return areEqual;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Book, BookDto>()
                .ForMember(
                    dest => dest.Author,
                    options => options.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName
                ));
        }
    }
}