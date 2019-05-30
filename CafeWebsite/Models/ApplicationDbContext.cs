using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CafeWebsite.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DBConn", throwIfV1Schema: false)
        {
        }
        public DbSet<MenuCat> MenuCats { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Subscribes> Subscribes { get; set; }
        public DbSet<StudioCat> StudioCats { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<MainDishes> MainDishes { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}