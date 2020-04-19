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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostCategory>()
            .HasKey(bc => new {bc.PostId, bc.CategoryId});

            modelBuilder.Entity<PostCategory>()
            .HasOne(bc => bc.Post) // tek bir post olabilecegi
            .WithMany(c => c.PostCategories) // birden fazla PostCategories olabilecegi
            .HasForeignKey(bc => bc.PostId); // foreign key PostId olacagi belirtilir

            modelBuilder.Entity<PostCategory>()
            .HasOne(bc => bc.Category)
            .WithMany(c => c.PostCategories)
            .HasForeignKey(bc => bc.CategoryId);            
        }      
    }
}
