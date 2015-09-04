using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderingSystem.Entities
{
    [Table("MenuItems")]
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "Menu Item Name must be between 1 and 20 characters long.")]
        [Required(ErrorMessage = "Menu Item Name is required.")]
        public string Name { get; set; }

        [StringLength(60, MinimumLength = 1, ErrorMessage = "Menu Item Description must be between 1 and 20 characters long.")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public double Price { get; set; }

        [StringLength(100, MinimumLength = 1, ErrorMessage = "Image Path must be between 1 and 100 characters long.")]
        [Required(ErrorMessage = "Image Path is required.")]
        public string ImagePath { get; set; }

        [ForeignKey("MenuCategory")]
        public int MenuCategoryId { get; set; }
        public MenuCategory MenuCategory { get; set; }

        public IList<OrderedItem> OrderedItems { get; set; }

    }
}