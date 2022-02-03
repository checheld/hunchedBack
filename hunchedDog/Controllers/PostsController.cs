using hunchedDog.PostsData;
using hunchedDogBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hunchedDog.Controllers
{
    [ApiController]
    public class PostsController : ControllerBase
    {
        private PostData _postData = new PostData();

        [HttpGet]
        [Route("posts/all")]
        public async Task<IActionResult> GetAllPosts()
        {
            
                return Ok(await _postData.GetAllPosts());
        }

        [HttpGet]
        /*[Authorize(Policy = "Bearer")]*/
        [Route("posts/post/{id}")]
        public async Task<IActionResult> GetPost(int id)
        {

            return Ok(await _postData.GetPost(id));
        }


        [HttpPost]
        [Route("posts/add")]
        public async Task<IActionResult> AddPost([FromBody] Post post)
        { 
                    var response = await _postData.AddPost(post);
                    return response != null ? Ok(response) : BadRequest("Post was not added - db is not connected");
        }

        [HttpPut]
        [Route("posts/post/{id}")]
        public async Task<IActionResult> EditPost([FromBody] Post post, int id)
        {
                var response = await _postData.EditPost(post, id);
            return response != null ? Ok(response) : NotFound("This post was not found");
        }
    }
}
