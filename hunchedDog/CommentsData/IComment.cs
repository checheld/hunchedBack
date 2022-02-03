using hunchedDogBackend.Models;

namespace hunchedDog.CommentsData
{
    public interface IComment
    {
        Task<Comment> AddComment(Comment comment);
        Task<List<Comment>> GetAllComments();
    }
}
