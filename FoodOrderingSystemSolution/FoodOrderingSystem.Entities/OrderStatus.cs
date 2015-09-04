using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderingSystem.Entities
{
    [Table("OrderStatuses")]
    public class OrderStatus
    {
        public int OrderStatusId { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessage = "Category Name must be between 1 and 20 characters long.")]
        [Required(ErrorMessage = "First Name is required.")]
        public string Status { get; set; }
        public List<Order> Orders { get; set; }
    }
}