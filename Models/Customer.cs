using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerApp.Models;

[Table("Customers")]
public partial class Customer
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Customer name is required.")]
    [StringLength(200)]
    [Display(Name = "Customer Name")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Address is required.")]
    [StringLength(500)]
    public string Address { get; set; } = null!;

    [StringLength(50)]
    [Display(Name = "Telephone Number")]
    public string? TelephoneNumber { get; set; }

    [StringLength(200)]
    [Display(Name = "Contact Person Name")]
    public string? ContactPersonName { get; set; }

    [StringLength(254)]
    [Display(Name = "Contact Person Email")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string? ContactPersonEmail { get; set; }

    [StringLength(50)]
    [Display(Name = "VAT Number")]
    public string? Vatnumber { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
