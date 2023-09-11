using BlogWeb.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogWeb.Data
{
    public class BlogieDbContext: DbContext
    {
        public BlogieDbContext(DbContextOptions options) : base(options) 
        {
        
        }
        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
