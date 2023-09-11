using BlogWeb.Data;
using BlogWeb.Data.Repository;
using BlogWeb.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Controllers
{
    public class AdminPostController : Controller
    {
        private IRepository _repo;
        public AdminPostController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult AddPost()
        {
            return View(new BlogPost());
        }


        [HttpPost]
        [ActionName("AddPost")]
        public async Task<IActionResult> Edit(BlogPost post) 
        {
            _repo.AddPost(post);

            if(await _repo.SaveChangeAsync())

                return RedirectToAction("AddPost");
            else
                return View(post);
        }
    }
}
