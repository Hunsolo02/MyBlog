using BlogWeb.Data.Repository;
using BlogWeb.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Controllers
{
    public class AllPostMenuController : Controller
    {
        private IRepository _repo;
        public AllPostMenuController(IRepository repo)
        {
            _repo = repo;
        }
        public IActionResult AllPostMenu()
        {
            var posts = _repo.GetAllPost();
            return View(posts);
        }
        
        public IActionResult BlogPost(int Id) 
        {
            var post = _repo.GetPost(Id);
            return View(post);
        }

        [HttpPost]
        [ActionName("AddPost")]
        public async Task<IActionResult> AddPost(BlogPost post)
        {
            if (post.Id > 0)
                _repo.UpdatePost(post);
            else
                _repo.AddPost(post);

            if (await _repo.SaveChangeAsync())

                return RedirectToAction("AllPostMenu");
            else
                return View(post);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int Id)
        {
            _repo.RemovePost(Id);
            await _repo.SaveChangeAsync();
            return RedirectToAction("AllPostMenu");
        }

    }
}
