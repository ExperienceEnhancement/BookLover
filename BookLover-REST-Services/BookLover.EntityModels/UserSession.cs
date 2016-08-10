namespace BookLover.EntityModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserSession
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        [MaxLength(1024)]
        public string AuthToken { get; set; }

        [Required]
        public DateTime ExpirationDateTime { get; set; }
    }
}
