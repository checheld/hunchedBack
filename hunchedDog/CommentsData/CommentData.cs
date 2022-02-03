using hunchedDogBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace hunchedDog.CommentsData
{
    public class CommentData : IComment
    {
        public async Task<Comment> AddComment(Comment comment)
        {
            using (HunchedContext db = new HunchedContext())
            {
                var comments = await db.Comments.ToListAsync();
                if (comments.Find(x => x.Id == comment.Id) == null)
                {
                    await db.Comments.AddAsync(comment);
                    await db.SaveChangesAsync();
                    return comment;
                }
                return null;
            }
        }

        public async Task<List<Comment>> GetAllComments()
        {
            using (HunchedContext db = new HunchedContext())
            {
                var allComments = await db.Comments.ToListAsync();
                if (allComments != null)
                {
                    return allComments;
                }
            }
            return null;
        }
    }
}