using hunchedDogBackend.Models;

namespace hunchedDog.PostsData
{
    public interface IPost
    {
        Task<List<Post>> GetAllPosts();
        Task<Post> GetPost(int id);
        Task<Post> AddPost(Post post);
        Task<Post> EditPost(Post post, int id);
    }
}

