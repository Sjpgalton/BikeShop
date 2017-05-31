using System.Text.RegularExpressions;

namespace Redweb.BikeShop.Core.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public CategoryModel Category { get; set; }
        public SubcategoryModel Subcategory { get; set; }
        public ProductModelModel Model { get; set; }
        public decimal Price { get; set; }
        public ColourModel Colour { get; set; }
        public SizeModel Size { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string DetailImageUrl => string.IsNullOrWhiteSpace(ImageUrl) ?
            "http://www.poorguytactical.com/home/Portals/0/CVStoreImages/default_product_image_400.jpg" 
            : ImageUrl;


        // Slug generation taken from 
        //http://stackoverflow.com/questions/2920744/url-slugify-algorithm-in-c
        public string GenerateSlug()
        {
            string phrase = string.Format("{0}-{1}", Id, Name);

            string str = RemoveAccent(phrase).ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        private string RemoveAccent(string text)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(text);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }
}