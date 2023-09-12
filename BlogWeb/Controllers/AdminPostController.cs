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
        public IActionResult AddPost(int? Id)
        {
            if (Id == null)
            {
                return View(new BlogPost());
            }
            else
            {
                var post = _repo.GetPost((int) Id);  
                return View(post);
            }
        }


        [HttpPost]
        [ActionName("AddPost")]
        public async Task<IActionResult> Edit(BlogPost post) 
        {
            if (post.Id > 0)
                _repo.UpdatePost(post);
            else
            _repo.AddPost(post);

            if(await _repo.SaveChangeAsync())

                return RedirectToAction("AddPost");
            else
                return View(post);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int Id) 
        {
            _repo.RemovePost(Id);
            await _repo.SaveChangeAsync();
            return RedirectToAction("AddPost");
        }
    }
}
