using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace JongBrabant.Kantinescherm.Models;

public class PriceList
{
    [DisplayName("Prijslijst")]
    public string Name { get; set; }
    public List<GroupEntry> Groups { get; set; }
    [Key]
    public int PriceListId { get; set; }
}

public class PriceListView
{
    public List<PriceListColumn> Columns { get; set; }
}

public class PriceListColumn
{
    public List<IGrouping<GroupEntry, ProductEntry>> Groups { get; set; }
    public bool IsLastColumn { get; set; }

    public object GetColumnClass()
    {
        if (IsLastColumn)
        {
            return "";
        }
        
        return "middle-column";
    }
}