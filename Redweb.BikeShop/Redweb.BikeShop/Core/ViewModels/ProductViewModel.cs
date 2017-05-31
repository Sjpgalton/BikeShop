using Redweb.BikeShop.Controllers;
using Redweb.BikeShop.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Redweb.BikeShop.Core.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Product Code")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "Please enter a Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please select a Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please select a Subcategory")]
        public int SubcategoryId { get; set; }

        [Required(ErrorMessage = "Please select a Model")]
        public int ModelId { get; set; }

        [Required(ErrorMessage = "Please enter a valid price (e.g. 199.99)")]
        public string Price { get; set; }

        public int? ColourId { get; set; }
        
        public int? SizeId { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }

        [Url(ErrorMessage = "Please enter a valid URL")]
        public string ImageUrl { get; set; }


        // To store all the values form the database
        public IEnumerable<CategoryModel> Categories { get; set; }
        public IEnumerable<SubcategoryModel> Subcategories { get; set; }
        public IEnumerable<ProductModelModel> Models { get; set; }

        public IEnumerable<ColourModel> Colours { get; set; }
        public IEnumerable<SizeModel> Sizes { get; set; }

        public string PageHeading { get; set; }
        public string Action
        {
            get
            {
                Expression<Func<ProductsController, ActionResult>> createProduct =
                    (c => c.AddProduct());

                Expression<Func<ProductsController, ActionResult>> updateProduct =
                    (c => c.UpdateProduct(this));

                var action = (Id != 0) ? updateProduct : createProduct;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

        public decimal GetPriceDecimalValue()
        {
            return decimal.Parse(Price);
        }

        public int GetSizeId()
        {
            if (SizeId == null)
            {
                return 0;
            }
            else
            {
                return SizeId.Value;
            }
        }

        public int GetColourId()
        {
            if (ColourId == null)
            {
                return 0;
            }
            else
            {
                return ColourId.Value;
            }
        }
    }
}