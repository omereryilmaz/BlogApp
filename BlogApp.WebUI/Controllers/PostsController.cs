using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogApp.Data.Context;
using BlogApp.Data.Models;
using BlogApp.Business.Repositories;

namespace BlogApp.WebUI.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PostsController(IPostRepository postRepository, ICategoryRepository categoryRepository)
        {           
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
        }

        // GET: Posts
        public IActionResult Index()
        {
            var posts = _postRepository.GetAll().AsQueryable().Include(x => x.PostCategories)
            .ThenInclude(c => c.Category).ToList();
            return View(posts);
        }

        // GET: Posts/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _postRepository.GetById(id.Value);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title,Content,CreatedDate,FullName,Id")] Post post, Guid[] PostCategories)
        {
            if (ModelState.IsValid)
            {
                post.PostCategories = new List<PostCategory>();
                foreach(var item in PostCategories)
                {
                    post.PostCategories.Add(new PostCategory{CategoryId = item});
                }
                _postRepository.Add(post);
                _postRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetAll(), "Id", "Name");
            return View(post);
        }

        // GET: Posts/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _postRepository.GetDefault(p => p.Id == id.Value)
                .AsQueryable()
                .Include(c => c.PostCategories)
                .ThenInclude(c => c.Category);

            if (post == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetAll(), "Id", "Name");
            ViewBag.CategoryIds = post.Select(c => c.PostCategories.Select(x => x.Category.Id)).ToArray();
            return View(post.First());
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Title,Content,CreatedDate,FullName,Id")] Post post, Guid[] PostCategories)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                     var ps = _postRepository.GetDefault(p => p.Id == id)
                        .AsQueryable()
                        .Include(c => c.PostCategories)
                        .ThenInclude(c => c.Category).First();
                    
                    ps.Title = post.Title;
                    ps.CreatedDate = post.CreatedDate;
                    ps.FullName = post.FullName;
                    ps.Content = post.Content;

                    ps.PostCategories.Clear();
                    foreach(var item in PostCategories)
                    {
                        ps.PostCategories.Add(new PostCategory{CategoryId = item});
                    }

                    _postRepository.Update(ps);
                    _postRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_postRepository.Any(x=>x.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetAll(), "Id", "Name");
            return View(post);
        }

        // GET: Posts/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _postRepository.GetById(id.Value);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {            
            _postRepository.Delete(id);
            _postRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
