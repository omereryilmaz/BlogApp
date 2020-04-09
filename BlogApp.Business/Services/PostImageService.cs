namespace BlogApp.Business.Services
{
    using Data.Context;
    using Data.Models;
    using Repositories;
    using System;
    public class PostImageService :Repository<PostImage>, IPostImageRepository
    {
        public PostImageService(BlogContext context):base(context){ }

        public void SetFalse(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}