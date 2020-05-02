namespace BlogApp.Business.Services
{
    using Data.Context;
    using Data.Models;
    using Repositories;
    using System.Collections.Generic;
    
    public class PostImageService : Repository<PostImage>, IPostImageRepository
    {
        public PostImageService(BlogContext context):base(context){ }

        public void SetFalse(IEnumerable<PostImage> images)
        {
            foreach (PostImage image in images)
            {
                image.Active = false;
            }
            Save();
        }
    }
}