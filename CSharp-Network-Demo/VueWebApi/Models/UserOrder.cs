using System;
using System.Collections.Generic;

namespace VueWebApi.Models;

public partial class UserOrder
{
    public int OrderId { get; set; }

    public string CustomerId { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public decimal TotalMoney { get; set; }

    public string OrderState { get; set; } = null!;
}
