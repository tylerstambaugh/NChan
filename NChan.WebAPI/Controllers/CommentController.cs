using Microsoft.AspNet.Identity;
using NChan.Models;
using NChan.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace NChan.WebAPI.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {
        public IHttpActionResult GetAllCommentsForPost([FromUri] int postId)
        {
            var cService = CreateCommentService();
            var comments = cService.GetCommentByPostId(postId);
            return Ok(comments);
        }

        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cService = CreateCommentService();

            if (!cService.CreateComment(comment))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult GetAllCommentsForAuthor(Guid authorId)
        {
            var cService = CreateCommentService();
            var comment = cService.GetCommentByAuthorId(authorId);
            return Ok(comment);
        }

        public IHttpActionResult Put(CommentEdit comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cService = CreateCommentService();

            if (!cService.UpdateComment(comment))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var cService = CreateCommentService();

            if (!cService.DeleteComment(id))
                return InternalServerError();

            return Ok();
        }

        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(userId);
            return commentService;
        }
    }
}