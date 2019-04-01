using WebSite.Data.DbInitializers.MenuInitializers;
using WebSite.Data.DbInitializers.SubMenuInitializers;
using WebSite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Data
{
    public class WebSiteDbContext : DbContext
    {
        public WebSiteDbContext(DbContextOptions<WebSiteDbContext>options):base(options)
        {

        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<SubMenu> SubMenus { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MenuInitializerConfiguration());
            modelBuilder.ApplyConfiguration(new SubMenuInitializerConfiguration());
        }

    }
}
