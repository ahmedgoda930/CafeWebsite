using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CafeWebsite.Models
{
    public class Reservation
    {
        [Key]
        public int ID { get; set; }
        public DateTime RDate { get; set; }
        public TimeSpan RTime { get; set; }
        public int PeapleNo { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Phone { get; set; }
    }
}