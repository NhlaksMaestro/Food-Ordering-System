using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderingSystem.Entities
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [StringLength(40, MinimumLength = 1, ErrorMessage = "First Name must be between 1 and 41 characters long.")]
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [StringLength(40, MinimumLength = 1, ErrorMessage = "Last Name must be between 1 and 41 characters long.")]
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [StringLength(40, MinimumLength = 1, ErrorMessage = "The Employees First Name must be between 1 and 41 characters long.")]
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [StringLength(10, MinimumLength = 1, ErrorMessage = "Phone must be between 10 digits long.")]
        [Required(ErrorMessage = "Address is required.")]
        public string Phone { get; set; }

        public List<Order> Orders { get; set; }

    }
}