using System.ComponentModel.DataAnnotations;

namespace MovieRatingWeb.Models
{
    public class CommentModel
    {
        [Key]
        public int CommentId { get; set; }

        [Required(ErrorMessage = "Comment text is required")]
        public string? Text { get; set; }

        public DateTime PostedAt { get; set; }

        // Foreign key to link to the User
        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}
