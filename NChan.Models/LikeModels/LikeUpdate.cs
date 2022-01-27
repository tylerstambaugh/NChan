using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NChan.Models.LikeModels
{
    public class LikeUpdate
    {
        public int Id { get; set; }
        public Guid OwnerId { get; set; }

        //[ForeignKey("Post")]
        public int PostID { get; set; }
    }
}
