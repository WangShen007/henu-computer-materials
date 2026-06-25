using System;
using System.Collections.Generic;

namespace VueWebApi.Models;

public partial class Good
{
    public int GoodsId { get; set; }

    public string GoodsName { get; set; } = null!;

    public int GoodsTypeId { get; set; }

    public string GoodsDescript { get; set; } = null!;

    public decimal GoodsUnitPrice { get; set; }

    public string GoodsImage { get; set; } = null!;

    public int SellCount { get; set; }

    public DateTime GoodsDate { get; set; }
}
