using System.ComponentModel.DataAnnotations;

namespace Redweb.BikeShop.Core.Models.DatabaseModels
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}