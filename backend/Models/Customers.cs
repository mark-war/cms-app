using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace backend.Models
{
    public partial class Customers
    {
        public int CustomerId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "First Name cannot be less than 2 characters.")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Last Name cannot be less than 2 characters.")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
    }
}
