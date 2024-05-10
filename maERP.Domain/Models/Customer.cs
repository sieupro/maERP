﻿using System.ComponentModel.DataAnnotations;
using maERP.Domain.Models.Common;

namespace maERP.Domain.Models;

public class Customer : BaseEntity
{
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
    [Required]
    public CustomerStatus CustomerStatus { get; set; }
    
    public ICollection<CustomerAddress>? CustomerAddresses { get; set; }
    public ICollection<Order>? Orders { get; set; }
    public DateTime DateEnrollment { get; set; }
}