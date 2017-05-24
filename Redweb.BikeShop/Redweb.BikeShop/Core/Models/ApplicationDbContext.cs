using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Redweb.BikeShop.Core.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}