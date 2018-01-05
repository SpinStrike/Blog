using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Review
    {
        [Required]
        [StringLength(1000, MinimumLength = 1)]
        public string ReviewText { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Author { get; set; }

        [Required]
        public DateTime Time { get; set; }
    }
}