using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLover.EntityModels
{
    using System.ComponentModel;
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
