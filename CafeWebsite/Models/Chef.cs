using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CafeWebsite.Models
{
    public class Chef
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string URL { get; set; }
        public string Content { get; set; }
    }
}