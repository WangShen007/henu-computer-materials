using System;
using System.Collections.Generic;

namespace VueWebApi.Models;

public partial class GoodsType
{
    public int GoodsTypeId { get; set; }

    public string GoodsTypeName { get; set; } = null!;
}
