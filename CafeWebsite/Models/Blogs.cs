using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CafeWebsite.Models
{
    public class Blogs
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [MaxLength(200)]
        public string URL { get; set; }
        public string Content { get; set; }
        public DateTime date { get; set; }
    }
}