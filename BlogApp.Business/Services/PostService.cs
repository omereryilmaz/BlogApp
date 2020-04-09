namespace BlogApp.Business.Services
{
    using Repositories;
    using Data.Context;
    using Data.Models;
    public class PostService : Repository<Post>, IPostRepository
    {
        public PostService(BlogContext context) : base(context){ }
    }
}
