using BlogWeb.Models.Domain;

namespace BlogWeb.Data.Repository
{
    public class Repository : IRepository
    {
        private BlogieDbContext _blogieDbContext;
        public Repository(BlogieDbContext blogieDbContext)
        {
            _blogieDbContext = blogieDbContext;
        }

        public List<BlogPost> GetAllPost()
        {
            return _blogieDbContext.BlogPosts.ToList();
        }

        public BlogPost GetPost(int Id)
        {
            return _blogieDbContext.BlogPosts.FirstOrDefault(p => p.Id == Id);
        }

        public void RemovePost(int Id)
        {
            _blogieDbContext.BlogPosts.Remove(GetPost(Id));
        }

        public void UpdatePost(BlogPost post)
        {
            _blogieDbContext.BlogPosts.Update(post);
        }

        public void AddPost(BlogPost post)
        {
            _blogieDbContext.BlogPosts.Add(post);
        }

        async Task<bool> IRepository.SaveChangeAsync()
        {
            if (await _blogieDbContext.SaveChangesAsync() > 0) 
            {
                return true;
            }
            return false;
        }
    }
}
