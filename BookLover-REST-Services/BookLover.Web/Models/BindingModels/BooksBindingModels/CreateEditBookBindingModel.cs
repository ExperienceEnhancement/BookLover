namespace BookLover.Web.Models.BindingModels.BooksBindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateEditBookBindingModel
    {
        [Required]
        public string Title { get; set; }

        public string Summary { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }
}