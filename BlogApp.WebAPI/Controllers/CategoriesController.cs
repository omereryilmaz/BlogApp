using BlogApp.Business.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApp.WebAPI.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public object Get()
        {
            return _categoryRepository.GetAll().Select(x => new
            {
                x.Id,
                x.Name
            });
        }
    }
}
