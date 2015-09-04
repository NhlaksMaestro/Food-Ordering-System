using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderingSystem.Web.Models
{
    [Table("OrderedItems")]
    public class OrderedItemModel
    {
        [Key, Column(Order = 1)]
        public int OrderedItemId { get; set; }

        //[Key, Column(Order = 2)]
        [ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }
        public virtual MenuItemModel MenuItem { get; set; }

        //[Key, Column(Order = 3)]
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual OrderModel Order { get; set; }

        [Required(ErrorMessage = "Please confirm the number of items ordered.")]
        public int Quantity { get; set; }
    }
}