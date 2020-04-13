namespace BlogApp.Business.Services
{
    using Data.Context;
    using Data.Models;
    using Repositories;
    public class CategoryService : Repository<Category>, ICategoryRepository
    {
        public CategoryService(BlogContext context) : base(context){ }       
    }
}
