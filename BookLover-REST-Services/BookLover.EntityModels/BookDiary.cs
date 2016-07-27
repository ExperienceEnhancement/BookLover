namespace BookLover.EntityModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public class BookDiary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        public int DiaryAccessId { get; set; }

        [ForeignKey("DiaryAccessId")]
        public virtual DiaryAccess DiaryAccess { get; set; }

        public virtual ICollection<DiaryNote> DiaryNotes { get; set; }
    }
}
