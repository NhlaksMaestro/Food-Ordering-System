using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderingSystem.Entities
{
    [Table("OrderedItems")]
    public class OrderedItem
    {
        [Key]
        public int OrderedItemId { get; set; }
        [ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Required(ErrorMessage = "Please confirm the number of items ordered.")]
        public int Quantity { get; set; }
    }
}