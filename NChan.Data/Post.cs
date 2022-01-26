using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NChan.Data
{
    public class Post
    {
        [Key]
        public int id { get; set; }
        [Required]
        string Title { get; set; }
        [Required]
        string Text { get; set; }
        [Required]
        List<Comment> comments { get; set; }
        [Required]
        List<Like> likes { get; set; }
        Guid AuthorId { get; set; }
    }
}