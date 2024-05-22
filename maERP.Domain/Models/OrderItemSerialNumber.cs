﻿using maERP.Domain.Models.Common;

namespace maERP.Domain.Models;

public class OrderItemSerialNumber : BaseEntity
{ 
    public int OrderItemId { get; set; }
    public string SerialNumber { get; set; } = string.Empty;
}