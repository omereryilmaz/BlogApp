namespace BlogApp.Business.Repositories
{
    using Data.Models;
    using System.Collections.Generic;

    public interface IPostImageRepository : IRepository<PostImage>
    {       
       void SetFalse(IEnumerable<PostImage> images);
    }  
}
