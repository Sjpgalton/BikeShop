using System.Data.Entity;
using Redweb.BikeShop.Core.Models.DatabaseModels;

namespace Redweb.BikeShop.Core
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Colour> Colours { get; set; }
        DbSet<Model> Models { get; set; }
        DbSet<Size> Sizes { get; set; }
        DbSet<Subcategory> Subcategories { get; set; }
        int SaveChanges();
    }
}