using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NChan.Models
{
    public class CommentListItem
    {
        [Display(Name = "Comment Id")]
        public int Id { get; set; }

        [Display(Name = "Comment Text")]
        public string Text { get; set; }
        public int PostId { get; set; }
    }
}
