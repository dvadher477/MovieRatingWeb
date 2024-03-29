using MovieRatingWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieRatingWeb.Data
{
    public class dbcontext:DbContext
    {
        public dbcontext(DbContextOptions<dbcontext>s) : base(s)
        { 
        
        }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<CommentModel> Comments { get; set; }

    }
}
