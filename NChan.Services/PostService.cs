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

        public PostService(Guid userId) 
        {
            _userId = userId;
        }

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
    }
}
