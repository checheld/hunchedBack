using hunchedDogBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace hunchedDog.PostsData
{
    public class PostData : IPost
    {
        public async Task<List<Post>> GetAllPosts()
        {
            using (HunchedContext db = new HunchedContext())
            {
                var posts = await db.Posts.ToListAsync();
                if (posts != null)
                {
                    return posts;
                }
            }
            return null;
        }

        public async Task<Post> GetPost(int id)
        {
            using (HunchedContext db = new HunchedContext())
            {
                var post = await db.Posts.SingleOrDefaultAsync(x => x.Id == id);
                if (post != null)
                {
                    return post;
                }
               
            }
            return null;
        }

        public async Task<Post> AddPost(Post post)
        {
            using (HunchedContext db = new HunchedContext())
            {
                var foundPost = await db.Posts.SingleOrDefaultAsync(x => x.Id == post.Id);
                if (foundPost == null)
                {
                    await db.Posts.AddAsync(post);
                    await db.SaveChangesAsync();
                    return post;
                }
                return null;
            }
        }

        public async Task<Post> EditPost(Post post, int id)
        {
            using (HunchedContext db = new HunchedContext())
            {
                var changingPost = await db.Posts.SingleOrDefaultAsync(x => x.Id == post.Id);
                post.Id = id;
                if (changingPost != null && changingPost != post)
                 {
                     db.Posts.Remove(changingPost);
                     changingPost = post;
                     await db.Posts.AddAsync(changingPost);
                     await db.SaveChangesAsync();
                     return post;
                 }
                 return null;
            }
        }
    }
}