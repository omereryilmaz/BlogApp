using BlogApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
        {}
        public virtual DbSet<Category> Categories {get; set;}
        public virtual DbSet<Post> Posts {get; set;}
        public virtual DbSet<PostImage> PostImages {get; set;}        
    }
}
