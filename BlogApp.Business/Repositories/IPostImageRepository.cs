namespace BlogApp.Business.Repositories
{
    using Data.Models;
    using System;
    public interface IPostImageRepository : IRepository<PostImage>
    {       
        void SetFalse(Guid Id);  
    }  
}
