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

        public IHttpActionResult CreatePost([FromBody] PostCreate postToCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PostService postService = CreatePostService();
            if (!postService.CreatePost(postToCreate))
                return InternalServerError();
                    return Ok();
        }
    }
}
