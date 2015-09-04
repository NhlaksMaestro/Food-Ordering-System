using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderingSystem.Web.Models
{
    [Table("Orders")]
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }

        [StringLength(10, MinimumLength = 1, ErrorMessage = "The Order Name must be between 1 and 41 characters long.")]
        [Required(ErrorMessage = "Order Status is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date Ordered is required.")]
        public DateTime DateOrdered { get; set; }

        [Required(ErrorMessage = "Date Received is required.")]
        public DateTime DateReceived { get; set; }

        [Required(ErrorMessage = "Amount Paid is required.")]
        public double AmountPaid { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual CustomerModel Customer { get; set; }
        public IList<OrderedItemModel> OrderedItems { get; set; }

        [ForeignKey("OrderStatus")]
        public int OrderStatusId { get; set; }
        public OrderStatusModel OrderStatus { get; set; }
    }
}