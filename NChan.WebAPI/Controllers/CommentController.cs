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
        public IHttpActionResult Get()
        {
            var cService = CreateCommentService();
            var comments = cService.GetComments();
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

        public IHttpActionResult Get(int id)
        {
            var cService = CreateCommentService();
            var comment = cService.GetCommentById(id);
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
            var commentService = new CommentService();
            return commentService;
        }
    }
}