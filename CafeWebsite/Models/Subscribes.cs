using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CafeWebsite.Models
{
    public class Subscribes
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
    }
}