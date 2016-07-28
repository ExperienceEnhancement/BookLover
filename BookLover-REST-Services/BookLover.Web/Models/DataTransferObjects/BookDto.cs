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

        public string Author { get; set; }

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