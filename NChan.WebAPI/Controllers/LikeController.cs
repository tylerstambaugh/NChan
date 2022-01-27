using Microsoft.AspNet.Identity;
using NChan.Models.LikeModels;
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
    public class LikeController : ApiController
    {
        private LikeService CreateLikeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var likeService = new LikeService(userId);
            return likeService;
        }

        [HttpPost]
        public IHttpActionResult AddLike([FromBody] LikeCreate likeCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            LikeService likeService = CreateLikeService();

            if (!likeService.CreateLike(likeCreate))
                return InternalServerError();

            return Ok("Liked added");
        }
        
        [HttpGet]
        public IHttpActionResult GetLikes([FromUri] int postId)
        {
            return Ok("still to do");
        }

        [HttpDelete]
        public IHttpActionResult DeleteLike([FromUri] int likeId)
        {
            LikeService likeService = CreateLikeService();
            if (!likeService.DeleteLike(likeId))
                return InternalServerError();

            return Ok("Like deleted");
        }

        [HttpPut]
        public IHttpActionResult UpdateALike()
        {
            return Ok();
        }
    }
}
