namespace BookLover.Web.Models.BindingModels.ReviewsBindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateReviewBindingModel
    {
        [Required]
        public string Comment { get; set; }

        [Required]
        public int Rate { get; set; }

        [Required]
        public int BookId { get; set; }
    }
}