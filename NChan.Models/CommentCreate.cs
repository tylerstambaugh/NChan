﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NChan.Models
{
    public class CommentCreate
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "There are too many charcters in this field. (Max 100)")]
        [Required]
        public string Text { get; set; }
    }
}
