using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CafeWebsite.Models
{
    public class Contacts
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Phone { get; set; }
        [Required]
        public string Message { get; set; }
    }
}