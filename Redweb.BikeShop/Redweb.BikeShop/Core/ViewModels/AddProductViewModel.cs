using Redweb.BikeShop.Controllers;
using Redweb.BikeShop.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Redweb.BikeShop.Core.ViewModels
{
    public class AddProductViewModel
    {
        public int Id { get; set; }

        [Required]
        public string ProductCode { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int SubcategoryId { get; set; }

        [Required]
        public int ModelId { get; set; }

        [Required]
        public string Price { get; set; }

        public int? ColourId { get; set; }
        
        public int? SizeId { get; set; }

        [Required]
        public string Description { get; set; }


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

                //Expression<Func<ProductsController, ActionResult>> updateProduct =
                //    (c => c.UpdateProduct(this));

                var action = /*(Id != 0) ? update : */createProduct;
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