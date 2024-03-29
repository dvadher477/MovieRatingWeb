using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace MovieRatingWeb.Models
{
    public class UserModel
    {
        [Key]
        public int UserId {  get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        public bool Remember { get; set; }

        public ICollection<CommentModel> Comments { get; set; }

    }
}

