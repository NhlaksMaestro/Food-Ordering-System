using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderingSystem.Web.Models
{
    [Table("MenuCategories")]
    public class MenuCategoryModel
    {
        [Key]
        public int MenuCategoryId { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessage = "Category Name must be between 1 and 20 characters long.")]
        [Required(ErrorMessage = "Category Name is required.")]
        public string CategoryName { get; set; }

        [StringLength(100, MinimumLength = 1, ErrorMessage = "Image Path must be between 1 and 100 characters long.")]
        [Required(ErrorMessage = "Image Path is required.")]
        public string ImagePath { get; set; }

        //public OrderModel Order { get; set; }
        public List<MenuItemModel> MenuItems { get; set; }
    }
}