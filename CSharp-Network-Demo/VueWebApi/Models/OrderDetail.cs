using System;
using System.Collections.Generic;

namespace VueWebApi.Models;

public partial class OrderDetail
{
    public int OrderId { get; set; }

    public int GoodsId { get; set; }

    public int GoodsCount { get; set; }
}
