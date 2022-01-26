using NChan.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NChan.Models
{
    public class CommentDetail
    {
        [Display(Name = "Comment Id")]
        public int Id { get; set; }

        [Display(Name = "Comment Text")]
        public string Text { get; set; }

        public ICollection<Post> Post { get; set; }
    }
}
