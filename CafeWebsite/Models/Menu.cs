using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CafeWebsite.Models
{
    public class Menu
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("MenuCat")]
        public int FK_CatID { get; set; }
        public MenuCat  MenuCat { get; set; }
        [Required]
        [MaxLength(200)]
        public string PName { get; set; }
        [Required]
        public double  Price { get; set; }
        public string Content { get; set; }
    }
}