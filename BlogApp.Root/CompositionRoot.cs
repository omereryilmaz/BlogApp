namespace BlogApp.Root
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.SqlServer;
    using Microsoft.Extensions.DependencyInjection;
    using BlogApp.Business.Repositories;
    using BlogApp.Business.Services;
    using BlogApp.Data.Context;

    public class CompositionRoot
    {
        public CompositionRoot(){}
        public static void InjectDependencies(IServiceCollection services)
        {
            services.AddScoped<BlogContext>();
            services.AddScoped(typeof(IPostRepository),typeof(PostService));
            services.AddScoped(typeof(IPostImageRepository),typeof(PostImageService));
            services.AddScoped(typeof(ICategoryRepository),typeof(CategoryService));
        
            services.AddDbContext<BlogContext>(options => options.UseSqlServer(
                @"Server=.\SQLExpress;Database=BlogDB;Integrated Security=true;",
                x => x.MigrationsAssembly("BlogApp.Data")));             
        }
    }
}