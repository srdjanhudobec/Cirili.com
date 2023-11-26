using C___.Data;
using C___.DTOs.Post;
using C___.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C___.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public readonly IPostService _posts;
        public readonly DatabaseContext _database;

        public PostController(IPostService posts, DatabaseContext database)
        {
            _posts = posts;
            _database = database;
        }
        /// <summary>
        /// Create post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost("create-post")]

        public ActionResult<PostPostResponse> createPost(PostPostRequest post)
        {
            var response = _posts.createPost(post, User.Identity.Name);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
        /// <summary>
        /// Get all posts
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-posts"),AllowAnonymous]

        public ActionResult<List<PostGetResponse>> getPosts()
        {
            var response = _posts.getPosts();
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        /// <summary>
        /// Get post by title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpGet("get-post-by-title"), AllowAnonymous]

        public ActionResult<PostGetResponse> getPostByTitle(string title)
        {
            var response = _posts.getPostByTitle(title);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        /// <summary>
        /// Get post by category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet("get-post-by-category"), AllowAnonymous]

        public ActionResult<List<PostGetResponse>> getPostByCategory(string category)
        {
            var response = _posts.getPostByCategory(category);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        /// <summary>
        /// Delete post by title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpDelete("delete-post")]

        public ActionResult<PostGetResponse> deletePost(string title)
        {
            var response = _posts.deletePost(title, User.Identity.Name);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
        /// <summary>
        /// Edit post by entering title of post
        /// </summary>
        /// <param name="title"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPut("update-post")]

        public ActionResult<PostPutResponse> updatePost(string title,PostPutRequest post)
        {
            var response = _posts.updatePost(title, User.Identity.Name, post);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
    }
}
