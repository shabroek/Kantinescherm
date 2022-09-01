using System.Collections.Generic;
using System.Linq;

namespace JongBrabant.Kantinescherm.Models;

public class PriceList
{
    public PriceListColumn Columns1 { get; set; }
    public PriceListColumn Columns2 { get; set; }
    public PriceListColumn Columns3 { get; set; }
}

public class PriceListColumn
{
    public List<IGrouping<GroupEntry, PriceEntry>> Groups { get; set; }
}