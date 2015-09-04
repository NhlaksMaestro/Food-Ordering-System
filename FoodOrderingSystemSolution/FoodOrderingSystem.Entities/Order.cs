using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderingSystem.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessage = "The Order Name must be between 1 and 41 characters long.")]
        [Required(ErrorMessage = "Order Status is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date Ordered is required.")]
        public DateTime DateOrdered { get; set; }

        //[Required(ErrorMessage = "Date Received is required.")]
        public DateTime? DateReceived { get; set; }

        //[Required(ErrorMessage = "Amount Paid is required.")]
        public double? AmountPaid { get; set; }

        //[Required(ErrorMessage = "Please confirm the number of items ordered.")]
        //public int Quantity { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public IList<OrderedItem> OrderedItems { get; set; }
    }
}