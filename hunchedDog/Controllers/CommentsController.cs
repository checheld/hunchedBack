using hunchedDog.CommentsData;
using hunchedDog.PostsData;
using hunchedDogBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace hunchedDog.Controllers
{
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private CommentData _commentData = new CommentData();


        [HttpPost]
        [Route("comments/add")]
        public async Task<IActionResult> AddComment([FromBody] Comment comment)
        {
            var response = await _commentData.AddComment(comment);
            return response != null ? Ok(response) : BadRequest("Comment was not added - db is not connected");
        }

        [HttpGet]
        [Route("comments/all")]
        public async Task<IActionResult> GetAllComments()
        {

            return Ok(await _commentData.GetAllComments());
        }

    }
}
