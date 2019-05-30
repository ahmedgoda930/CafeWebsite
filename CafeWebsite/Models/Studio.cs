using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CafeWebsite.Models
{
    public class Studio
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("StudioCat")]
        public int FK_CatID { get; set; }
        public virtual StudioCat StudioCat { get; set; }
        [MaxLength(200)]
        public string URL { get; set; }
    }
}