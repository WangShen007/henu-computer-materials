using System;
using System.Collections.Generic;

namespace VueWebApi.Models;

public partial class Customer
{
    public string CustomerId { get; set; } = null!;

    public string CustomerPwd { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string CustomerAddress { get; set; } = null!;

    public string CustomerPostCode { get; set; } = null!;

    public string CustomerPhone { get; set; } = null!;

    public string? CostomerEmail { get; set; }

    public DateTime CustomerRegDate { get; set; }
}
