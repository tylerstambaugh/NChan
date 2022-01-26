using NChan.Data;
using NChan.Models.LikeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NChan.Services
{
    public class LikeService
    {
        //methods that write data to the database.
        private readonly Guid _userId;
        public LikeService(Guid userId)
        {
            _userId = userId;
        }

        //create a like in the DB

        public bool CreateLike(LikeCreate likeModel)
        {
            Like likeEntity = new Like()
            {
                OwnerId = _userId,
                PostID = likeModel.PostId,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(likeEntity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<LikeListItem> GetLikes(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Likes.Where(l => l.PostID == postId)
                    .Select(
                        l =>
                            new LikeListItem
                            {
                                Id = l.Id,
                                OwnerId = l.OwnerId,
                                PostID = l.PostID
                            }
                        );
                return query.ToArray();
                }
        }

        //update a like

        public bool UpdateALike(int likeId, LikeUpdate updatedLike)
        {
            using (var ctx = new ApplicationDbContext())
            {

                Like likeToUpdate =
                    ctx
                    .Likes
                    .Single(l => l.Id == updatedLike.Id && l.OwnerId == _userId);

                likeToUpdate.PostID = updatedLike.PostID;

                return ctx.SaveChanges() == 1;
            }
        }

        //delete a like
        public bool DeleteLike(int likeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var likeToRemove = ctx.Likes.Find(likeId);
                ctx.Likes.Remove(likeToRemove);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
