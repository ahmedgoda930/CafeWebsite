using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CafeWebsite.Models
{
    public class AboutUs
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string ImageURL { get; set; }
        [Required]
        [MaxLength(200)]
        public string VedioURL { get; set; }
        public string Content { get; set; }
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
        [Required]
        [MaxLength(200)]
        public string Phone { get; set; }
    }
}