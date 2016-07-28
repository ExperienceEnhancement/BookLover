namespace BookLover.EntityModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DiaryNote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int BookDiaryId { get; set; }

        public virtual BookDiary BookDiary { get; set; }
    }
}
