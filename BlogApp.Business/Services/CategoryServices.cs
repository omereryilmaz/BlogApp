namespace BlogApp.Business.Services
{
    using Data.Context;
    using Data.Models;
    using Repositories;
    public class CategoryServices : Repository<Category>, ICategoryRepository
    {
        public CategoryServices(BlogContext context) : base(context){ }       
    }
}
