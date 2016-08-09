namespace BookLover.Web.Models.DataTransferObjects
{
    using AutoMapper;
    using Common.Mappings;
    using EntityModels;

    public class ReviewDto: IMapFrom<Review>, IHaveCustomMappings
    {
        public string Comment { get; set; }

        public int Rate { get; set; }

        public string Username { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Review, ReviewDto>()
                .ForMember(
                    dest => dest.Username,
                    options => options.MapFrom(src => src.User.UserName
                ));
        }
    }
}