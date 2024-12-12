using System;
using System.Collections.Generic;

namespace SWD.FlowerShop.Repos.Entities;

public partial class Revenue
{
    public int RevenueId { get; set; }

    public string MonthYear { get; set; } = null!;

    public decimal TotalRevenue { get; set; }

    public DateTime? CreatedAt { get; set; }
}
