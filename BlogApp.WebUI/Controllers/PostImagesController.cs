using System;
using BlogApp.Business.Repositories;
using BlogApp.Data.Models;
using BlogApp.WebUI.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FileResult = BlogApp.WebUI.Utility.FileResult;

namespace BlogApp.WebUI.Controllers
{
    public class PostImagesController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IPostImageRepository _postImageRepository;
        private readonly IFileUpload _fileUpload;
        public PostImagesController(IPostRepository postRepository,
            IPostImageRepository postImageRepository,
            IFileUpload fileUpload)
        {
            this._postRepository = postRepository;
            this._postImageRepository = postImageRepository;
            this._fileUpload = fileUpload;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Upload(Guid? id)
        {
            if (id.Value == null)
            {
                return RedirectToAction("Index","Posts");
            }
            return View(id);
        }

        [HttpPost]
        public IActionResult Upload(IFormFile[] file, Guid? id)
        {
            if(id.HasValue)
            {
                Post post = _postRepository.GetById(id.Value);
                if (post == null)
                {
                    return NotFound();
                }
                if (file.Length > 0)
                {
                    foreach (var item in file)
                    {
                        var result = _fileUpload.Upload(item);
                        if (result.FileResult == FileResult.Succeeded)
                        {
                            PostImage image = new PostImage{
                                ImageUrl = result.FileUrl,
                                PostId = id.Value
                            };   

                            _postImageRepository.Add(image);
                            _postImageRepository.Save();                           
                        }
                    }
                }
            }
            return View(id);
        }
    }
}