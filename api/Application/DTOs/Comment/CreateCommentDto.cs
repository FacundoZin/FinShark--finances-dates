using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "title must be at least 5 characters")]
        [MaxLength(40, ErrorMessage = "title cannot be over 45 characters")]
        public string Title { get; set; } = string.Empty;


        [Required]
        [MinLength(5, ErrorMessage = "content must be at least 5 characters")]
        [MaxLength(250, ErrorMessage = "content cannot be over 45 characters")]
        public string Content { get; set; } = string.Empty;

    }
}