namespace BookLover.EntityModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Review
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int BookId { get; set; }

        [Required]
        [Column(TypeName = "ntext")]
        public string Comment { get; set; }

        [Required]
        public int Rate { get; set; }

        public virtual User User { get; set; }

        public virtual Book Book { get; set; }
    }
}
