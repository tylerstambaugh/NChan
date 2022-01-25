﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NChan.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Guid AuthorId { get; set; }

        [ForeignKey("Post"), Required]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
