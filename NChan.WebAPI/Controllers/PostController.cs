using Microsoft.AspNet.Identity;
using NChan.Models;
using NChan.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NChan.WebAPI.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(userId);
            return postService;
        }

        [HttpPost]
        public IHttpActionResult CreatePost([FromBody] PostCreate postToCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PostService postService = CreatePostService();
            if (!postService.CreatePost(postToCreate))
                return InternalServerError();
                    return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetAllPosts()
        {
            PostService postService = CreatePostService();
            var allPosts = postService.GetAllPosts();
            if(allPosts != null)
            return Ok(allPosts);

            return BadRequest();
        }

        [HttpGet]
        public IHttpActionResult GetPostsByAuthor([FromUri] Guid authorId)
        {
            PostService postService = CreatePostService();
            var postsByAtuhor = postService.GetAllPostByUser(authorId);
            if(postsByAtuhor != null)
            return Ok(postsByAtuhor);
            return InternalServerError();
            

        }

        [HttpDelete]
        public IHttpActionResult DeletePostById([FromUri] int postId)
        {
            PostService postService = CreatePostService();
            if (postService.DeleteAPost(postId))
                return Ok();
            return InternalServerError();
        }

        [HttpPut]
        public IHttpActionResult UpdateAPost([FromBody] PostEdit postToEdit)
        {
            PostService postService = CreatePostService();
            if (postService.UpdateAPost(postToEdit))
                return Ok("Post updated");
            return BadRequest();
        }
    }
}
