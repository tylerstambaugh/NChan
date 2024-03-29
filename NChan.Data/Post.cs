﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NChan.Data
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();
        [Required]
        public virtual List<Like> Likes { get; set; } = new List<Like>();
        
        public Guid AuthorId { get; set; }
    }
}