using BlogApp.Business.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BlogApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        public PostsController(IPostRepository postRepository, ICategoryRepository categoryRepository)
        {
            this._postRepository = postRepository;
            this._categoryRepository = categoryRepository;
        }       

        [HttpGet("{id}")]
        public object Get(Guid id)
        {
            var posts = _categoryRepository.GetDefault(c => c.Id == id)
            .AsQueryable()
            .Include(c => c.PostCategories)
            .ThenInclude(c => c.Post)
            .ThenInclude(c => c.PostImages)
            .Select(p => new{
                PostCategories = p.PostCategories.Select(p => new {
                    p.PostId,
                    p.Post.Title,
                    p.Post.Content,
                    p.Post.CreatedDate,
                    p.Post.FullName,
                    img = p.Post.PostImages.Where(i => i.Active == true)
                    .Select(i => $"http://localhost:5000{i.ImageUrl}")
                    .First() ?? ""
                })
            });
            return posts;
        } 
    }
}
