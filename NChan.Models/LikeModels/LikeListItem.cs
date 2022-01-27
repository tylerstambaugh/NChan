using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NChan.Models.LikeModels
{
    public class LikeListItem
    {
       //[Key, Required]
        public int Id { get; set; }

        public Guid OwnerId { get; set; }

       // [ForeignKey("Post")]
        public int PostID { get; set; }

       // public virtual Post Post { get; set; }
    }
}
