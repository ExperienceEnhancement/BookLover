namespace BookLover.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Column(TypeName= "ntext")]
        public string Summary { get; set; }

        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
