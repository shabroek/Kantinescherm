using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JongBrabant.Kantinescherm.Models;

public class GroupEntry
{
    [Key]
    public int GroupId { get; set; }
    public IEnumerable<ProductEntry> Products { get; set; }
    [DisplayName("Groep")]
    public string GroupName { get; set; }
    [DisplayName("Volgorde")]
    public int Order { get; set; }

    [DisplayName("Toon titel")]
    public bool ShowHeader { get; set; }

    public int PriceListId { get; set; }
    public PriceList PriceList { get; set; }
}