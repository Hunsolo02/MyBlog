using BlogWeb.Models.Domain;

namespace BlogWeb.Data.Repository
{
    public interface IRepository
    {
        BlogPost GetPost(int Id);
        List<BlogPost> GetAllPost();
        void AddPost(BlogPost post);
        void RemovePost(int Id);
        void UpdatePost(BlogPost post);
        Task<bool> SaveChangeAsync();
    }
}
