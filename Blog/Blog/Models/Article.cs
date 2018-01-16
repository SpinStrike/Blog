using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Article
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Tags { get; set; }

        [Required]
        public DateTime PublishingTime { get; set; }
    }
}