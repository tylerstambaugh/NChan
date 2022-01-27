using NChan.Data;
using NChan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NChan.Services
{
    public class PostService
    {
        private readonly Guid _userId;
        // writing entities to the DB


        //constructor to set the user, called by the controller to get user in context.
        public PostService(Guid userId) 
        {
            _userId = userId;
        }

        //use PostCreate model to add a post to the database.
        public bool CreatePost(PostCreate postCreateModel)
        {
            Post postToCreate = new Post()
            {
                AuthorId = _userId,
                Title = postCreateModel.Title,
                Text = postCreateModel.Text

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(postToCreate);
                return ctx.SaveChanges() == 1;
            }
        }

        //Get all posts from the data base.
        public IEnumerable<PostListItem> GetAllPosts()

        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Select(
                            p =>
                                new PostListItem
                                {
                                    Id = p.Id,
                                    Title = p.Title,
                                    Text = p.Text
                                }
                                );
                return query.ToArray();
            }
        }

        //get all posts for a given user ID

        public IEnumerable<PostDetail> GetAllPostByUser(Guid userId)

        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                         .Where(p => p.AuthorId == _userId)
                        .Select(
                            p =>
                                new PostDetail
                                {
                                    Id = p.Id,
                                    Title = p.Title,
                                    Text = p.Text,
                                    AuthorId = p.AuthorId
                                }
                                );
                return query.ToArray();
            }
        }


        //update a post based on a new PostEdit model
        public bool UpdateAPost(PostEdit postToEdit)
        {
            using (var ctx = new ApplicationDbContext())
            {
               Post editedPost =
                    ctx
                        .Posts
                        .Single(p => p.Id == postToEdit.Id);
                editedPost.Text = postToEdit.Text;
                editedPost.Title = postToEdit.Title;
                return ctx.SaveChanges() == 1;
            }

        }


        //delete a post using the PostId
        public bool DeleteAPost(int postId)
        {

            using (var ctx = new ApplicationDbContext())
            {
                Post postToDelete = ctx.Posts.Find(postId);
                ctx.Posts.Remove(postToDelete);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
